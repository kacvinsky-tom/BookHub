﻿using AutoMapper;
using Core.DTO.Input.Genre;
using Core.DTO.Output.Genre;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebAPI.Extensions;

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

        var genresListDto = _mapper.Map<BookGenreListOutputDto>(genres);

        return Ok(genresListDto);
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
        try
        {
            var genre = await _genreService.Update(genreInputDto, id);

            return Ok(_mapper.Map<GenreDetailOutputDto>(genre));
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
            await _genreService.Delete(id);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}
