using System.Linq.Expressions;
using AutoMapper;
using Core.DTO.Input.Book;
using Core.DTO.Input.Search;
using Core.DTO.Output;
using Core.DTO.Output.Book;
using Core.Exception;
using Core.Helpers;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Filter;
using DataAccessLayer.Helpers;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Services;

public class BookService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMemoryCache _memoryCache;
    private readonly IMapper _mapper;

    public BookService(UnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _memoryCache = memoryCache;
    }

    public async Task<Book?> GetById(int id)
    {
        if (_memoryCache.TryGetValue("book-" + id, out Book? cachedBook))
        {
            return cachedBook;
        }

        var book = await _unitOfWork.Books.GetByIdWithRelations(id);

        if (book != null)
        {
            _memoryCache.Set("book-" + id, book);
        }

        return book;
    }

    public async Task<IEnumerable<Book>> GetAll(BookFilterInputDto? filterInputDto = null)
    {
        if (filterInputDto == null)
        {
            return await _unitOfWork.Books.GetAll();
        }

        return await _unitOfWork.Books.GetAll(_mapper.Map<BookFilter>(filterInputDto));
    }

    public async Task<PaginationObject<Book>> GetAllPaginated(
        int page,
        int pageSize,
        Expression<Func<Book, IComparable>>? orderingExpression = null,
        bool reverseOrder = false
    )
    {
        var ordering = new Ordering<Book>
        {
            Expression = orderingExpression ?? (b => b.Title),
            Reverse = reverseOrder
        };

        return await _unitOfWork.Books.GetAllPaginated(page, pageSize, null, new[] { ordering });
    }

    public async Task<PaginatedResult<BookListOutputDto>> Search(
        SearchQueryInputDto searchQuery,
        int page,
        int pageSize
    )
    {
        var bookFilter = new BookFilter { FullTextSearch = searchQuery.Query, };

        var paginatedBooksQuery = await _unitOfWork.Books.GetAllPaginated(
            page,
            pageSize,
            bookFilter
        );

        return new PaginatedResult<BookListOutputDto>
        {
            Items = paginatedBooksQuery.Items.Select(_mapper.Map<BookListOutputDto>),
            TotalCount = paginatedBooksQuery.TotalItems
        };
    }

    public async Task<Book> Create(BookCreateInputDto bookCreateCreateInputDto)
    {
        var publisher = await _unitOfWork.Publishers.GetById(bookCreateCreateInputDto.PublisherId);
        var authors = (
            await _unitOfWork.Authors.Find(
                author => bookCreateCreateInputDto.AuthorIds.Contains(author.Id)
            )
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
            await _unitOfWork.Genres.Find(
                genre => bookCreateCreateInputDto.GenreIds.Contains(genre.Id)
            )
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

        if (bookCreateCreateInputDto.PrimaryGenreId != null)
        {
            await SetPrimaryGenre(book.Id, bookCreateCreateInputDto.PrimaryGenreId.Value);
        }

        return book;
    }

    public async Task<Book> Update(BookCreateInputDto bookCreateUpdateInputDto, int id)
    {
        var book = await _unitOfWork.Books.GetByIdWithRelations(id);

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
            await _unitOfWork.Authors.Find(
                author => bookCreateUpdateInputDto.AuthorIds.Contains(author.Id)
            )
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
            await _unitOfWork.Genres.Find(
                genre => bookCreateUpdateInputDto.GenreIds.Contains(genre.Id)
            )
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

        book.Genres.Where(g => !genres.Contains(g)).ToList().ForEach(g => book.Genres.Remove(g));
        genres.Where(g => !book.Genres.Contains(g)).ToList().ForEach(g => book.Genres.Add(g));

        book.Authors.Where(a => !authors.Contains(a)).ToList().ForEach(a => book.Authors.Remove(a));
        authors.Where(a => !book.Authors.Contains(a)).ToList().ForEach(a => book.Authors.Add(a));

        await _unitOfWork.Complete();

        if (bookCreateUpdateInputDto.PrimaryGenreId != null)
        {
            await SetPrimaryGenre(book.Id, bookCreateUpdateInputDto.PrimaryGenreId.Value);
        }

        _memoryCache.Set("book-" + id, book);

        return book;
    }

    private async Task<Book> SetPrimaryGenre(int bookId, int genreId)
    {
        var book = await _unitOfWork.Books.GetByIdWithRelations(bookId);

        if (book == null)
        {
            throw new EntityNotFoundException<Book>(bookId);
        }

        var bookGenre = book.BookGenres.FirstOrDefault(bg => bg.GenreId == genreId);

        if (bookGenre == null)
        {
            var genre = await _unitOfWork.Genres.GetById(genreId);
            if (genre == null)
            {
                throw new EntityNotFoundException<Genre>(genreId);
            }

            bookGenre = new BookGenre
            {
                BookId = book.Id,
                GenreId = genre.Id,
                IsPrimary = true,
            };
            book.BookGenres.Add(bookGenre);

            await _unitOfWork.Complete();
            return book;
        }

        book.BookGenres.ToList().ForEach(bg => bg.IsPrimary = false);
        bookGenre.IsPrimary = true;

        await _unitOfWork.Complete();

        _memoryCache.Set("book-" + bookId, book);

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

        _memoryCache.Remove("book-" + bookId);
    }
}
