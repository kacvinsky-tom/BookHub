using BookHub.API.DTO.Input;
using BookHub.API.Mapper;
using BookHub.DataAccessLayer;
using BookHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly AuthorService _authorService;

    public AuthorController(UnitOfWork unitOfWork, AuthorService authorService)
    {
        _unitOfWork = unitOfWork;
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var authors = await _unitOfWork.Authors.GetAll();

        return Ok(authors.Select(AuthorMapper.MapList));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var author = await _unitOfWork.Authors.GetByIdWithRelations(id);

        if (author == null)
        {
          return NotFound();
        }

        return Ok(AuthorMapper.MapDetail(author));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AuthorInputDto authorInputDto)
    {
        var author = _authorService.Create(authorInputDto);
        _unitOfWork.Authors.Add(author);
        await _unitOfWork.Complete();
        return Ok(AuthorMapper.MapDetail(author));
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
        return Ok(AuthorMapper.MapDetail(author));
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