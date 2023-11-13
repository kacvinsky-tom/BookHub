using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.Genre;
using WebAPI.DTO.Output.Genre;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly GenreService _genreService;
    private readonly IMapper _mapper;

    public GenreController(GenreService genreService, IMapper mapper)
    {
        _genreService = genreService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var genres = await _genreService.GetAll();

        return Ok(genres.Select(_mapper.Map<GenreListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var genre = await _genreService.GetById(id);

        if (genre == null)
        {
          return NotFound();
        }

        return Ok(_mapper.Map<GenreDetailOutputDto>(genre));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] GenreInputDto genreInputDto)
    {
        var genre = await _genreService.Create(genreInputDto);

        return Ok(_mapper.Map<GenreDetailOutputDto>(genre));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] GenreInputDto genreInputDto)
    {
        var genre =  await _genreService.Update(genreInputDto, id);

        return Ok(_mapper.Map<GenreDetailOutputDto>(genre));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _genreService.Delete(id);

        return Ok();
    }
}