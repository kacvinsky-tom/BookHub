using AutoMapper;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.Author;
using WebAPI.DTO.Output.Author;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly AuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorController(UnitOfWork unitOfWork, AuthorService authorService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var authors = await _unitOfWork.Authors.GetAll();

        return Ok(authors.Select(_mapper.Map<AuthorListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var author = await _unitOfWork.Authors.GetByIdWithRelations(id);

        if (author == null)
        {
          return NotFound();
        }

        return Ok(_mapper.Map<AuthorDetailOutputDto>(author));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AuthorInputDto authorInputDto)
    {
        var author = _authorService.Create(authorInputDto);
        _unitOfWork.Authors.Add(author);
        await _unitOfWork.Complete();
        return Ok(_mapper.Map<AuthorDetailOutputDto>(author));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] AuthorInputDto authorInputDto)
    {
        var author = await _unitOfWork.Authors.GetById(id);

        if (author == null)
        {
          return NotFound();
        }
          
        _authorService.Update(authorInputDto, author);
        await _unitOfWork.Complete();
        return Ok(_mapper.Map<AuthorDetailOutputDto>(author));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var author = await _unitOfWork.Authors.GetById(id);

        if (author == null)
        {
          return NotFound();
        }

        _unitOfWork.Authors.Remove(author);

        await _unitOfWork.Complete();

        return Ok();
    }

}