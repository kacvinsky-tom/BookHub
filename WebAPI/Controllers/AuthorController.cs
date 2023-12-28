﻿using AutoMapper;
using Core.DTO.Input.Author;
using Core.DTO.Output.Author;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly AuthorService _authorService;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public AuthorController(AuthorService authorService, IMapper mapper, IMemoryCache memoryCache)
    {
        _authorService = authorService;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        if (_memoryCache.TryGetValue("authors", out var cachedAuthors))
        {
            return Ok(cachedAuthors);
        }

        var authors = await _authorService.GetAll();

        var authorListDto = _mapper.Map<AuthorListOutputDto>(authors);

        _memoryCache.Set("authors", authorListDto);

        return Ok(authorListDto);
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

        _memoryCache.Remove("authors");

        return Ok(_mapper.Map<AuthorDetailOutputDto>(author));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] AuthorInputDto authorInputDto)
    {
        try
        {
            var author = await _authorService.Update(authorInputDto, id);

            _memoryCache.Remove("authors");

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

            _memoryCache.Remove("authors");

            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}
