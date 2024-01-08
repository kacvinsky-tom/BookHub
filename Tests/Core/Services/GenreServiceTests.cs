using Core.DTO.Input.Genre;
using Core.Exception;
using Core.Services;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Tests.Utilities.Data;
using Tests.Utilities.MockedObjects;
using Xunit;

namespace Tests.Core.Services;

public class GenreServiceTests
{
    private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;

    public GenreServiceTests()
    {
        var genreRepositoryMock = Substitute.For<IGenreRepository>();

        genreRepositoryMock.GetAll().Returns(GenreTestData.GetFakeGenres());
        genreRepositoryMock.GetById(1).Returns(GenreTestData.GetFakeGenres().First());
        genreRepositoryMock.GetByIdWithRelations(1).Returns(GenreTestData.GetFakeGenres().First());

        _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
            .AddCaching()
            .ConfigureIdentity()
            .AddLogging()
            .AddUnitOfWork()
            .AddAutoMapper()
            .AddRepositories()
            .AddScoped(genreRepositoryMock)
            .AddServices()
            .AddMockedDbContext();
    }

    [Fact]
    public async Task GetAllGenres_ReturnsGenres()
    {
        // Arrange
        var genres = GenreTestData.GetFakeGenres().ToList();
        var genresIds = genres.Select(g => g.Id).ToList();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var genreService = scope.ServiceProvider.GetRequiredService<GenreService>();

        // Act
        var result = (await genreService.GetAll()).ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(genres.Count, result.Count);
        Assert.All(result, genreSummary => Assert.Contains(genreSummary.Id, genresIds));
    }

    [Fact]
    public async Task GetGenreById_ReturnsGenre()
    {
        // Arrange
        var genre = GenreTestData.GetFakeGenres().First();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var genreService = scope.ServiceProvider.GetRequiredService<GenreService>();

        // Act
        var result = await genreService.GetById(genre.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(genre.Id, result.Id);
    }

    [Fact]
    public async Task CreateGenre_ReturnsGenre()
    {
        // Arrange
        var genreInputDto = new GenreInputDto { Name = "TestGenre" };
        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var genreService = scope.ServiceProvider.GetRequiredService<GenreService>();

        // Act
        var result = await genreService.Create(genreInputDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(genreInputDto.Name, result.Name);
    }

    [Fact]
    public async Task UpdateGenre_ReturnsCorrectlyUpdatedGenre()
    {
        // Arrange
        const int genreIdToUpdate = 1;
        var genreUpdateDto = new GenreInputDto() { Name = "UpdatedGenre" };
        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var genreService = scope.ServiceProvider.GetRequiredService<GenreService>();

        // Act
        var result = await genreService.Update(genreUpdateDto, genreIdToUpdate);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(genreUpdateDto.Name, result.Name);
    }

    [Fact]
    public async Task UpdateGenre_WrongId_ThrowsCorrectException()
    {
        // Arrange
        const int genreIdToUpdate = 999;
        var genreUpdateDto = new GenreInputDto() { Name = "UpdatedGenre" };
        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var genreService = scope.ServiceProvider.GetRequiredService<GenreService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Genre>>(
            () => genreService.Update(genreUpdateDto, genreIdToUpdate)
        );
    }
}
