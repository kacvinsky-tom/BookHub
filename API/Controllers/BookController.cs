using BookHub.API.Mapper;
using BookHub.DataAccessLayer;
using BookHub.DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    
    public BookController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var books = await _unitOfWork.Books.GetWithRelations();
        
        return Ok(books.Select(BookMapper.Map));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var book = await _unitOfWork.Books.GetById(id);
        
        if (book == null)
        {
            return NotFound();
        }

        return Ok(BookMapper.Map(book));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        _unitOfWork.Books.Add(book);
        await _unitOfWork.Complete();

        return Ok(BookMapper.Map(book));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(Book book, int id)
    {
        var bookToUpdate = await _unitOfWork.Books.GetById(id);
        
        if (bookToUpdate == null)
        {
            return NotFound();
        }
        
        bookToUpdate.Title = book.Title;
        bookToUpdate.ISBN = book.ISBN;
        bookToUpdate.Description = book.Description;
        bookToUpdate.Image = book.Image;
        bookToUpdate.Price = book.Price;
        bookToUpdate.Quantity = book.Quantity;
        bookToUpdate.Publisher = book.Publisher;
        bookToUpdate.ReleaseYear = book.ReleaseYear;
        bookToUpdate.AuthorId = book.AuthorId;
        bookToUpdate.Author = book.Author;
        bookToUpdate.Genres = book.Genres;

        await _unitOfWork.Complete();

        return Ok(BookMapper.Map(bookToUpdate));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _unitOfWork.Books.GetById(id);
        
        if (book == null)
        {
            return NotFound();
        }
        
        _unitOfWork.Books.Remove(book);
        await _unitOfWork.Complete();

        return Ok();
    }
}