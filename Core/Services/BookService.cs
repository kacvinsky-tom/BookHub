using Core.DTO.Input.Book;
using Core.Exception;
using DataAccessLayer;
using DataAccessLayer.Entity;

namespace Core.Services;

public class BookService
{
    private readonly UnitOfWork _unitOfWork;

    public BookService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Book?> GetById(int id)
    {
        return await _unitOfWork.Books.GetByIdWithRelations(id);
    }

    public async Task<IEnumerable<Book>> GetAll(BookFilterInputDto filterInputDto)
    {
        return await _unitOfWork.Books.GetWithRelations(filterInputDto.ToBookFilter());
    }

    public async Task<Book> Create(BookCreateInputDto bookCreateCreateInputDto)
    {
        var publisher = await _unitOfWork.Publishers.GetById(bookCreateCreateInputDto.PublisherId);
        var authors = (
            await _unitOfWork
                .Authors
                .Find(author => bookCreateCreateInputDto.AuthorIds.Contains(author.Id))
        ).ToList();

        if (!authors.Any())
        {
            throw new EntityNotFoundException<Author>(
                bookCreateCreateInputDto.AuthorIds.FirstOrDefault()
            );
        }
        if (publisher == null)
        {
            throw new EntityNotFoundException<Publisher>(bookCreateCreateInputDto.PublisherId);
        }

        var genres = (
            await _unitOfWork
                .Genres
                .Find(genre => bookCreateCreateInputDto.GenreIds.Contains(genre.Id))
        ).ToList();

        if (!genres.Any())
        {
            throw new EntityNotFoundException<Genre>(
                bookCreateCreateInputDto.GenreIds.FirstOrDefault()
            );
        }

        var book = new Book
        {
            Title = bookCreateCreateInputDto.Title,
            ISBN = bookCreateCreateInputDto.ISBN,
            Description = bookCreateCreateInputDto.Description,
            Image = bookCreateCreateInputDto.Image,
            Price = bookCreateCreateInputDto.Price,
            Quantity = bookCreateCreateInputDto.Quantity,
            PublisherId = bookCreateCreateInputDto.PublisherId,
            ReleaseYear = bookCreateCreateInputDto.ReleaseYear,
            IsDeleted = false,
            Authors = authors,
            Genres = genres,
        };

        await _unitOfWork.Books.Add(book);

        await _unitOfWork.Complete();

        return book;
    }

    public async Task<Book> Update(BookCreateInputDto bookCreateUpdateInputDto, int id)
    {
        var book = await _unitOfWork.Books.GetById(id);

        if (book == null)
        {
            throw new EntityNotFoundException<Book>(id);
        }

        var publisher = await _unitOfWork.Publishers.GetById(bookCreateUpdateInputDto.PublisherId);

        if (publisher == null)
        {
            throw new EntityNotFoundException<Publisher>(bookCreateUpdateInputDto.PublisherId);
        }

        var authors = (
            await _unitOfWork
                .Authors
                .Find(author => bookCreateUpdateInputDto.AuthorIds.Contains(author.Id))
        ).ToList();

        if (!authors.Any())
        {
            throw new EntityNotFoundException<Author>(
                bookCreateUpdateInputDto.AuthorIds.FirstOrDefault()
            );
        }
        if (publisher == null)
        {
            throw new EntityNotFoundException<Publisher>(bookCreateUpdateInputDto.PublisherId);
        }

        var genres = (
            await _unitOfWork
                .Genres
                .Find(genre => bookCreateUpdateInputDto.GenreIds.Contains(genre.Id))
        ).ToList();

        if (!genres.Any())
        {
            throw new EntityNotFoundException<Genre>(
                bookCreateUpdateInputDto.GenreIds.FirstOrDefault()
            );
        }

        book.Title = bookCreateUpdateInputDto.Title;
        book.ISBN = bookCreateUpdateInputDto.ISBN;
        book.Description = bookCreateUpdateInputDto.Description;
        book.Image = bookCreateUpdateInputDto.Image;
        book.Price = bookCreateUpdateInputDto.Price;
        book.Quantity = bookCreateUpdateInputDto.Quantity;
        book.PublisherId = bookCreateUpdateInputDto.PublisherId;
        book.ReleaseYear = bookCreateUpdateInputDto.ReleaseYear;
        book.Authors = authors;
        book.Genres = genres;

        await _unitOfWork.Complete();

        return book;
    }

    public async Task Delete(int bookId)
    {
        var book = await _unitOfWork.Books.GetById(bookId);

        if (book == null)
        {
            throw new EntityNotFoundException<Book>(bookId);
        }

        book.IsDeleted = true;

        await _unitOfWork.Complete();
    }
}
