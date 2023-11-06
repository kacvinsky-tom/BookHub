using AutoMapper;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.Genre;
using WebAPI.DTO.Output.Genre;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly GenreService _genreService;
    private readonly IMapper _mapper;

    public GenreController(UnitOfWork unitOfWork, GenreService genreService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _genreService = genreService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var genres = await _unitOfWork.Genres.GetAll();

        return Ok(genres.Select(_mapper.Map<GenreListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var genre = await _unitOfWork.Genres.GetByIdWithRelations(id);

        if (genre == null)
        {
          return NotFound();
        }

        return Ok(_mapper.Map<GenreDetailOutputDto>(genre));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GenreInputDto genreInputDto)
    {
        var genre = _genreService.Create(genreInputDto);
        _unitOfWork.Genres.Add(genre);
        await _unitOfWork.Complete();
        return Ok(_mapper.Map<GenreDetailOutputDto>(genre));
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
        return Ok(_mapper.Map<GenreDetailOutputDto>(genre));
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