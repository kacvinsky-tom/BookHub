using AutoMapper;
using Core.DTO.Input.Book;
using Core.DTO.Output.Book;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;
    private readonly IMapper _mapper;
    
    public BookController(BookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
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
        var book = await _bookService.GetById(id);
        
        if (book == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<BookDetailOutputDto>(book));
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
    public async Task<IActionResult> Update([FromBody] BookCreateInputDto bookCreateUpdateInputDto, int id)
    {
        try
        {
            var book = await _bookService.Update(bookCreateUpdateInputDto, id);
            
            return Ok(_mapper.Map<BookDetailOutputDto>(book));
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
            
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}