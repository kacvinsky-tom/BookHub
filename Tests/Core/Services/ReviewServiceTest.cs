using Core.Services;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Tests.Utilities.Data;
using Tests.Utilities.MockedObjects;
using Xunit;

namespace Tests.Core.Services;

public class ReviewServiceTest
{
    private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;

    public ReviewServiceTest()
    {
        var reviewRepositoryMock = Substitute.For<IReviewRepository>();

        reviewRepositoryMock.GetAll().Returns(ReviewTestData.GetFakeReviews());
        reviewRepositoryMock.GetAllWithRelations().Returns(ReviewTestData.GetFakeReviews());
        reviewRepositoryMock.GetById(1).Returns(ReviewTestData.GetFakeReviews().First());
        reviewRepositoryMock
            .GetByIdWithRelations(1)
            .Returns(ReviewTestData.GetFakeReviews().First());

        var bookRepositoryMock = Substitute.For<IBookRepository>();

        bookRepositoryMock.GetById(1).Returns(BookTestData.GetFakeBooks().First());

        var userRepositoryMock = Substitute.For<IUserRepository>();

        userRepositoryMock.GetById(1).Returns(UserTestData.GetFakeUsers().First());

        _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
            .AddCaching()
            .ConfigureIdentity()
            .AddLogging()
            .AddUnitOfWork()
            .AddAutoMapper()
            .AddRepositories()
            .AddScoped(reviewRepositoryMock)
            .AddScoped(bookRepositoryMock)
            .AddScoped(userRepositoryMock)
            .AddServices()
            .AddMockedDbContext();
    }

    [Fact]
    public async Task GetAllReviews_ReturnsReviews()
    {
        // Arrange
        var reviews = ReviewTestData.GetFakeReviews().ToList();
        var reviewsIds = reviews.Select(r => r.Id).ToList();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var reviewService = scope.ServiceProvider.GetRequiredService<ReviewService>();

        // Act
        var result = (await reviewService.GetAll()).ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(reviews.Count, result.Count);
        Assert.All(result, reviewSummary => Assert.Contains(reviewSummary.Id, reviewsIds));
    }

    [Fact]
    public async Task GetReviewById_ReturnsReview()
    {
        // Arrange
        var review = ReviewTestData.GetFakeReviews().First();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var reviewService = scope.ServiceProvider.GetRequiredService<ReviewService>();

        // Act
        var result = await reviewService.GetById(review.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(review.Id, result.Id);
    }

    [Fact]
    public async Task GetReviewByIdWithRelations_ReturnsReview()
    {
        // Arrange
        var review = ReviewTestData.GetFakeReviews().First();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var reviewService = scope.ServiceProvider.GetRequiredService<ReviewService>();

        // Act
        var result = await reviewService.GetById(review.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(review.Id, result.Id);
    }

    [Fact]
    public async Task CreateReview_ReturnsReview()
    {
        // Arrange
        var review = ReviewTestData.GetFakeReviewCreateInputDto();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var reviewService = scope.ServiceProvider.GetRequiredService<ReviewService>();

        // Act
        var result = await reviewService.Create(review);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(review.Comment, result.Comment);
    }

    [Fact]
    public async Task UpdateReview_ReturnsReview()
    {
        // Arrange
        var review = ReviewTestData.GetFakeReviewUpdateInputDto();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var reviewService = scope.ServiceProvider.GetRequiredService<ReviewService>();

        // Act
        var result = await reviewService.Update(review, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(review.Comment, result.Comment);
    }
}
