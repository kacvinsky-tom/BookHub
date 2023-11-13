using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.Book;
using WebAPI.DTO.Output.Book;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly BookService _bookService;
    private readonly IMapper _mapper;
    
    public BookController(UnitOfWork unitOfWork, BookService bookService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
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
        catch (EntityNotFoundException<Author> e)
        {
            return NotFound(e.Message);
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
        catch (EntityNotFoundException<Author> e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _unitOfWork.Books.GetById(id);

        if (book == null)
        {
            return NotFound();
        }
        _bookService.Delete(book);
        await _unitOfWork.Complete();

        return Ok();
    }
}