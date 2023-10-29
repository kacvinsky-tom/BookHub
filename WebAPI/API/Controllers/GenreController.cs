using BookHub.API.DTO.Input;
using BookHub.API.Mapper;
using BookHub.Services;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly GenreService _genreService;

    public GenreController(UnitOfWork unitOfWork, GenreService genreService)
    {
        _unitOfWork = unitOfWork;
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var genres = await _unitOfWork.Genres.GetAll();

        return Ok(genres.Select(GenreMapper.MapList));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var genre = await _unitOfWork.Genres.GetByIdWithRelations(id);

        if (genre == null)
        {
          return NotFound();
        }

        return Ok(GenreMapper.MapDetail(genre));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GenreInputDto genreInputDto)
    {
        var genre = _genreService.Create(genreInputDto);
        _unitOfWork.Genres.Add(genre);
        await _unitOfWork.Complete();
        return Ok(GenreMapper.MapDetail(genre));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] GenreInputDto genreInputDto)
    {
        var genre = await _unitOfWork.Genres.GetById(id);

        if (genre == null)
        {
          return NotFound();
        }
          
        _genreService.Update(genreInputDto, genre);
        await _unitOfWork.Complete();
        return Ok(GenreMapper.MapDetail(genre));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var genre = await _unitOfWork.Genres.GetById(id);

        if (genre == null)
        {
          return NotFound();
        }

        _unitOfWork.Genres.Remove(genre);

        await _unitOfWork.Complete();

        return Ok();
    }

}