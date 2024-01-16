using AutoMapper;
using Core.DTO.Input.Author;
using Core.DTO.Output;
using Core.DTO.Output.Author;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> FetchPaginated(int page = 1, int pageSize = 10)
    {
        var authors = await _authorService.GetAllPaginated(page, pageSize);

        var paginatedAuthors = _mapper.Map<PaginatedResult<AuthorListOutputDto>>(authors);

        return Ok(paginatedAuthors);
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
        catch (CannotDeleteException)
        {
            return Conflict("Cannot delete author because it has books.");
        }
    }
}
