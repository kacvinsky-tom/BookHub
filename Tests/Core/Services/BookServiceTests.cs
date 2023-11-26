using System.Linq.Expressions;
using Core.DTO.Input.Book;
using Core.Exception;
using Core.Services;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Filter;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Tests.Utilities.Data;
using Tests.Utilities.MockedObjects;
using Xunit;

namespace Tests.Core.Services;

public class BookServiceTests
{
    private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;
    private readonly BookHubDbContext _mockedContext;

    public BookServiceTests()
    {
        var options = MockedDbContext.GenerateNewInMemoryDbContextOptions();
        _mockedContext = MockedDbContext.CreateFromOptions(options);

        var bookRepositoryMock = Substitute.For<IBookRepository>();
        var authorRepositoryMock = Substitute.For<IAuthorRepository>();
        var genreRepositoryMock = Substitute.For<IGenreRepository>();
        var publisherRepositoryMock = Substitute.For<IPublisherRepository>();

        bookRepositoryMock
            .GetWithRelations(Arg.Any<BookFilter>())
            .Returns(BookTestData.GetFakeBooks());
        bookRepositoryMock.GetByIdWithRelations(1).Returns(BookTestData.GetFakeBooks().First());
        bookRepositoryMock.GetById(1).Returns(BookTestData.GetFakeBooks().First());

        authorRepositoryMock.GetById(1).Returns(BookTestData.GetFakeBookAuthors().First());

        authorRepositoryMock
            .Find(Arg.Any<Expression<Func<Author, bool>>>())
            .Returns(args =>
            {
                var expression = args.Arg<Expression<Func<Author, bool>>>();
                var result = BookTestData.GetFakeBookAuthors().Where(expression.Compile());
                return Task.FromResult(result);
            });

        genreRepositoryMock.GetById(1).Returns(new Genre() { Id = 1, Name = "Fantasy" });

        genreRepositoryMock
            .Find(Arg.Any<Expression<Func<Genre, bool>>>())
            .Returns(args =>
            {
                var expression = args.Arg<Expression<Func<Genre, bool>>>();
                var result = BookTestData.GetFakeGenres().Where(expression.Compile());
                return Task.FromResult(result);
            });

        publisherRepositoryMock
            .GetById(1)
            .Returns(new Publisher() { Id = 1, Name = "Test Publisher" });

        _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
            .AddUnitOfWork()
            .AddAutoMapper()
            .AddRepositories()
            .AddScoped<IBookRepository>(bookRepositoryMock)
            .AddScoped<IAuthorRepository>(authorRepositoryMock)
            .AddScoped<IGenreRepository>(genreRepositoryMock)
            .AddScoped<IPublisherRepository>(publisherRepositoryMock)
            .AddServices()
            .AddMockedDbContext();
    }

    [Fact]
    public async Task BookCreate_ValidData_DoesNotThrow()
    {
        // Arrange
        var fakeAuthor = BookTestData.GetFakeBookAuthors().First();
        var fakeGenre = BookTestData.GetFakeGenres().First();
        var bookInputDto = new BookCreateInputDto()
        {
            AuthorIds = new List<int>() { fakeAuthor.Id },
            Title = "New Book",
            Description = "New Description",
            ISBN = "1234567890123",
            Price = 200,
            Quantity = 20,
            ReleaseYear = 2022,
            PublisherId = 1,
            GenreIds = new List<int>() { fakeGenre.Id }
        };

        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act
        var result = await bookService.Create(bookInputDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bookInputDto.Title, result.Title);
        Assert.Equal(bookInputDto.Description, result.Description);
        Assert.Equal(bookInputDto.ISBN, result.ISBN);
        Assert.Equal(bookInputDto.Price, result.Price);
        Assert.Equal(bookInputDto.Quantity, result.Quantity);
        Assert.Equal(bookInputDto.ReleaseYear, result.ReleaseYear);
        Assert.Equal(bookInputDto.PublisherId, result.PublisherId);
        Assert.Equivalent(fakeAuthor, result.Authors.First());
        Assert.Equivalent(fakeGenre, result.Genres.First());
    }

    [Fact]
    public async Task BookCreate_WrongGenre_DoesThrow()
    {
        // Arrange
        var legitFakeAuthor = BookTestData.GetFakeBookAuthors().First();
        var bookInputDto = new BookCreateInputDto()
        {
            AuthorIds = new List<int>() { legitFakeAuthor.Id },
            Title = "New Book",
            Description = "New Description",
            ISBN = "1234567890123",
            Price = 200,
            Quantity = 20,
            ReleaseYear = 2022,
            PublisherId = 1,
            GenreIds = new List<int>() { 999 }
        };

        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Genre>>(
            () => bookService.Create(bookInputDto)
        );
    }

    [Fact]
    public async Task BookCreate_WrongAuthor_DoesThrow()
    {
        // Arrange
        var legitFakeGenre = BookTestData.GetFakeGenres().First();
        var bookInputDto = new BookCreateInputDto()
        {
            AuthorIds = new List<int>() { 999 },
            Title = "New Book",
            Description = "New Description",
            ISBN = "1234567890123",
            Price = 200,
            Quantity = 20,
            ReleaseYear = 2022,
            PublisherId = 1,
            GenreIds = new List<int>() { legitFakeGenre.Id }
        };

        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Author>>(
            () => bookService.Create(bookInputDto)
        );
    }

    [Fact]
    public async Task BookCreate_WrongPublisher_DoesThrow()
    {
        // Arrange
        var legitFakeGenre = BookTestData.GetFakeGenres().First();
        var legitFakeAuthor = BookTestData.GetFakeBookAuthors().First();
        var bookInputDto = new BookCreateInputDto()
        {
            AuthorIds = new List<int>() { legitFakeAuthor.Id },
            Title = "New Book",
            Description = "New Description",
            ISBN = "1234567890123",
            Price = 200,
            Quantity = 20,
            ReleaseYear = 2022,
            PublisherId = 999,
            GenreIds = new List<int>() { legitFakeGenre.Id }
        };

        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Publisher>>(
            () => bookService.Create(bookInputDto)
        );
    }

    [Fact]
    public async Task Book_GetAll_ReturnsAllBooks()
    {
        // Arrange
        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act
        var result = await bookService.GetAll(new BookFilterInputDto());

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task Book_GetById_ReturnsBook()
    {
        // Arrange
        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();
        var correctBook = BookTestData.GetFakeBooks().First();

        // Act
        var result = await bookService.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(correctBook.Id, result.Id);
    }

    [Fact]
    public async Task Book_GetById_ReturnsNull()
    {
        // Arrange
        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act
        var result = await bookService.GetById(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task BookDelete_ValidData_DoesNotThrow()
    {
        // Arrange
        var book = BookTestData.GetFakeBooks().First();

        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act
        await bookService.Delete(book.Id);

        // Assert
        Assert.DoesNotContain(book, _mockedContext.Books);
    }

    [Fact]
    public async Task BookDelete_WrongId_DoesThrow()
    {
        // Arrange
        var book = BookTestData.GetFakeBooks().First();

        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Book>>(() => bookService.Delete(999));
    }

    [Fact]
    public async Task BookUpdate_ValidData_DoesNotThrow()
    {
        // Arrange
        var book = BookTestData.GetFakeBooks().First();
        var bookInputDto = new BookCreateInputDto()
        {
            AuthorIds = book.Authors.Select(author => author.Id).ToList(),
            Title = "New Book",
            Description = "New Description",
            ISBN = "1234567890123",
            Price = 200,
            Quantity = 20,
            ReleaseYear = 2022,
            PublisherId = 1,
            GenreIds = book.Genres.Select(genre => genre.Id).ToList()
        };

        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act
        var result = await bookService.Update(bookInputDto, book.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(bookInputDto.Title, result.Title);
        Assert.Equal(bookInputDto.Description, result.Description);
        Assert.Equal(bookInputDto.ISBN, result.ISBN);
        Assert.Equal(bookInputDto.Price, result.Price);
        Assert.Equal(bookInputDto.Quantity, result.Quantity);
        Assert.Equal(bookInputDto.ReleaseYear, result.ReleaseYear);
        Assert.Equal(bookInputDto.PublisherId, result.PublisherId);
        Assert.Equivalent(book.Authors, result.Authors);
        Assert.Equivalent(book.Genres, result.Genres);
    }

    [Fact]
    public async Task BookUpdate_WrongGenre_DoesThrow()
    {
        // Arrange
        var book = BookTestData.GetFakeBooks().First();
        var bookInputDto = new BookCreateInputDto()
        {
            AuthorIds = book.Authors.Select(author => author.Id).ToList(),
            Title = "New Book",
            Description = "New Description",
            ISBN = "1234567890123",
            Price = 200,
            Quantity = 20,
            ReleaseYear = 2022,
            PublisherId = 1,
            GenreIds = new List<int>() { 999 }
        };

        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Genre>>(
            () => bookService.Update(bookInputDto, book.Id)
        );
    }

    [Fact]
    public async Task BookUpdate_WrongAuthor_DoesThrow()
    {
        // Arrange
        var book = BookTestData.GetFakeBooks().First();
        var bookInputDto = new BookCreateInputDto()
        {
            AuthorIds = new List<int>() { 999 },
            Title = "New Book",
            Description = "New Description",
            ISBN = "1234567890123",
            Price = 200,
            Quantity = 20,
            ReleaseYear = 2022,
            PublisherId = 1,
            GenreIds = book.Genres.Select(genre => genre.Id).ToList()
        };

        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Author>>(
            () => bookService.Update(bookInputDto, book.Id)
        );
    }

    [Fact]
    public async Task BookUpdate_WrongPublisher_DoesThrow()
    {
        // Arrange
        var book = BookTestData.GetFakeBooks().First();
        var bookInputDto = new BookCreateInputDto()
        {
            AuthorIds = book.Authors.Select(author => author.Id).ToList(),
            Title = "New Book",
            Description = "New Description",
            ISBN = "1234567890123",
            Price = 200,
            Quantity = 20,
            ReleaseYear = 2022,
            PublisherId = 999,
            GenreIds = book.Genres.Select(genre => genre.Id).ToList()
        };

        var serviceProvider = _serviceProviderBuilder.Create();
        using var scope = serviceProvider.CreateScope();
        var bookService = scope.ServiceProvider.GetRequiredService<BookService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Publisher>>(
            () => bookService.Update(bookInputDto, book.Id)
        );
    }
}
