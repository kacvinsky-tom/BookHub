using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core.DTO.Input.Author;
using Core.DTO.Output.Author;
using Core.Exception;
using Core.Services;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly AuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorController(AuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var authors = await _authorService.GetAll();

        return Ok(authors.Select(_mapper.Map<AuthorListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var author = await _authorService.GetById(id);

        if (author == null)
        {
          return NotFound();
        }

        return Ok(_mapper.Map<AuthorDetailOutputDto>(author));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AuthorInputDto authorInputDto)
    {
        var author = await _authorService.Create(authorInputDto);

        return Ok(_mapper.Map<AuthorDetailOutputDto>(author));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] AuthorInputDto authorInputDto)
    {
        try
        {
            var author = await _authorService.Update(authorInputDto, id);

            return Ok(_mapper.Map<AuthorDetailOutputDto>(author));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _authorService.Delete(id);

            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }

}