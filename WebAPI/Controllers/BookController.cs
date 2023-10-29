using BookHub.InputType;
using BookHub.InputType.Filter;
using BookHub.Mapper;
using BookHub.Services;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly BookService _bookService;
    
    public BookController(UnitOfWork unitOfWork, BookService bookService)
    {
        _unitOfWork = unitOfWork;
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch([FromQuery] BookFilterInput filterInput)
    {
        var books = await _unitOfWork.Books.GetWithRelations(filterInput.ToBookFilter());
        
        return Ok(books.Select(BookMapper.MapList));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var book = await _unitOfWork.Books.GetByIdWithRelations(id);
        
        if (book == null)
        {
            return NotFound();
        }

        return Ok(BookMapper.MapDetail(book));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookInput bookCreateInput)
    {
        try
        {
            var book = await _bookService.Create(bookCreateInput);
            
            _unitOfWork.Books.Add(book);

            await _unitOfWork.Complete();

            return Ok(BookMapper.MapDetail(book));
        }
        catch (EntityNotFoundException<Author> e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromBody] BookInput bookUpdateInput, int id)
    {
        var bookToUpdate = await _unitOfWork.Books.GetById(id);
        
        if (bookToUpdate == null)
        {
            return NotFound();
        }

        try
        {
            await _bookService.Update(bookUpdateInput, bookToUpdate);
            
            await _unitOfWork.Complete();
            
            return Ok(BookMapper.MapDetail(bookToUpdate));
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