using Core.DTO.Input.Author;
using Core.Services;
using DataAccessLayer;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Tests.Utilities.Data;
using Tests.Utilities.MockedObjects;
using Xunit;

namespace Tests.Core.Services;

public class AuthorServiceTests
{
    private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;
    private readonly BookHubDbContext _mockedContext;

    public AuthorServiceTests()
    {
        var options = MockedDbContext.GenerateNewInMemoryDbContextOptions();
        _mockedContext = MockedDbContext.CreateFromOptions(options);

        var authorRepositoryMock = Substitute.For<IAuthorRepository>();

        authorRepositoryMock.GetAll().Returns(AuthorTestData.GetFakeAuthors());
        authorRepositoryMock
            .GetById(Arg.Any<int>())
            .Returns(AuthorTestData.GetFakeAuthors().First());
        authorRepositoryMock
            .GetByIdWithRelations(1)
            .Returns(AuthorTestData.GetFakeAuthors().First());

        _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
            .ConfigureIdentity()
            .AddLogging()
            .AddUnitOfWork()
            .AddAutoMapper()
            .AddRepositories()
            .AddScoped<IAuthorRepository>(authorRepositoryMock)
            .AddServices()
            .AddMockedDbContext();
    }

    [Fact]
    public async Task GetAllAuthors_ReturnsAuthors()
    {
        // Arrange
        var authors = AuthorTestData.GetFakeAuthors().ToList();
        var authorsIds = authors.Select(a => a.Id).ToList();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var authorService = scope.ServiceProvider.GetRequiredService<AuthorService>();

        // Act
        var result = (await authorService.GetAll()).ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(authors.Count, result.Count);
        Assert.All(result, authorSummary => Assert.Contains(authorSummary.Id, authorsIds));
    }

    [Fact]
    public async Task GetAuthorById_ReturnsAuthor()
    {
        // Arrange
        var author = AuthorTestData.GetFakeAuthors().First();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var authorService = scope.ServiceProvider.GetRequiredService<AuthorService>();

        // Act
        var result = await authorService.GetById(author.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(author.Id, result.Id);
        Assert.Equal(author.FirstName, result.FirstName);
        Assert.Equal(author.LastName, result.LastName);
    }

    [Fact]
    public async Task GetAuthorById_Wrong_ReturnsNull()
    {
        // Arrange
        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var authorService = scope.ServiceProvider.GetRequiredService<AuthorService>();

        // Act
        var result = await authorService.GetById(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateAuthor_ReturnsAuthor()
    {
        // Arrange
        var author = new AuthorInputDto() { FirstName = "Test", LastName = "Test", };

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var authorService = scope.ServiceProvider.GetRequiredService<AuthorService>();

        // Act
        var result = await authorService.Create(author);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(author.FirstName, result.FirstName);
        Assert.Equal(author.LastName, result.LastName);
    }

    [Fact]
    public async Task UpdateAuthor_ReturnsAuthor()
    {
        // Arrange
        var author = new AuthorInputDto() { FirstName = "Test", LastName = "Test" };

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var authorService = scope.ServiceProvider.GetRequiredService<AuthorService>();

        // Act
        var result = await authorService.Update(author, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(author.FirstName, result.FirstName);
        Assert.Equal(author.FirstName, result.LastName);
    }
}
