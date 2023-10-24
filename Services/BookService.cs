using BookHub.API.InputType;
using BookHub.DataAccessLayer;
using BookHub.DataAccessLayer.Entity;
using BookHub.DataAccessLayer.Exception;

namespace BookHub.Services;

public class BookService
{
    private readonly UnitOfWork _unitOfWork;
    
    public BookService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Book> Create(BookInput bookCreateInput)
    {
        var author = await _unitOfWork.Authors.GetById(bookCreateInput.AuthorId);
        var publisher = await _unitOfWork.Publishers.GetById(bookCreateInput.PublisherId);
        
        if (author == null)
        {
            throw new EntityNotFoundException<Author>(bookCreateInput.AuthorId);
        }
        if (publisher == null)
        {
            throw new EntityNotFoundException<Publisher>(bookCreateInput.PublisherId);
        }
        
        var genres = await _unitOfWork.Genres
            .Find(genre => bookCreateInput.GenreIds.Contains(genre.Id));

        var book = new Book
        {
            Title = bookCreateInput.Title,
            ISBN = bookCreateInput.ISBN,
            Description = bookCreateInput.Description,
            Image = bookCreateInput.Image,
            Price = bookCreateInput.Price,
            Quantity = bookCreateInput.Quantity,
            PublisherId = bookCreateInput.PublisherId,
            ReleaseYear = bookCreateInput.ReleaseYear,
            IsDeleted = false,
            AuthorId = bookCreateInput.AuthorId,
            Author = author,
            Genres = genres.ToList(),
        };

        return book;
    }
    
    public async Task Update(BookInput bookUpdateInput, Book book)
    {
        var author = await _unitOfWork.Authors.GetById(bookUpdateInput.AuthorId);
        var publisher = await _unitOfWork.Publishers.GetById(bookUpdateInput.PublisherId);
        
        if (author == null)
        {
            throw new EntityNotFoundException<Author>(bookUpdateInput.AuthorId);
        }
        if (publisher == null)
        {
            throw new EntityNotFoundException<Publisher>(bookUpdateInput.PublisherId);
        }
        
        var genres = await _unitOfWork.Genres
            .Find(genre => bookUpdateInput.GenreIds.Contains(genre.Id));

        book.Title = bookUpdateInput.Title;
        book.ISBN = bookUpdateInput.ISBN;
        book.Description = bookUpdateInput.Description;
        book.Image = bookUpdateInput.Image;
        book.Price = bookUpdateInput.Price;
        book.Quantity = bookUpdateInput.Quantity;
        book.PublisherId = bookUpdateInput.PublisherId;
        book.ReleaseYear = bookUpdateInput.ReleaseYear;
        book.IsDeleted = bookUpdateInput.IsDeleted;
        book.AuthorId = bookUpdateInput.AuthorId;
        book.Author = author;
        book.Genres = genres.ToList();
    }
}