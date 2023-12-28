using AutoMapper;
using Core.DTO.Input.Book;
using Core.DTO.Output.Book;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public BookController(BookService bookService, IMapper mapper, IMemoryCache memoryCache)
    {
        _bookService = bookService;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch([FromQuery] BookFilterInputDto filterInputDto)
    {
        var books = await _bookService.GetAll(filterInputDto);

        return Ok(books.Select(_mapper.Map<BookListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        if (_memoryCache.TryGetValue("book-" + id, out var cachedBook))
        {
            return Ok(cachedBook);
        }

        var book = await _bookService.GetById(id);

        if (book == null)
        {
            return NotFound();
        }

        var bookDetailDto = _mapper.Map<BookDetailOutputDto>(book);

        _memoryCache.Set("book-" + id, bookDetailDto);

        return Ok(bookDetailDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookCreateInputDto bookCreateCreateInputDto)
    {
        try
        {
            var book = await _bookService.Create(bookCreateCreateInputDto);

            return Ok(_mapper.Map<BookDetailOutputDto>(book));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        [FromBody] BookCreateInputDto bookCreateUpdateInputDto,
        int id
    )
    {
        try
        {
            var book = await _bookService.Update(bookCreateUpdateInputDto, id);

            var bookDetailDto = _mapper.Map<BookDetailOutputDto>(book);

            _memoryCache.Set("book-" + id, bookDetailDto);

            return Ok(bookDetailDto);
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
            await _bookService.Delete(id);

            _memoryCache.Remove("book-" + id);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}
