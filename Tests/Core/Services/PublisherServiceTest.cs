using Core.Services;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Tests.Utilities.Data;
using Tests.Utilities.MockedObjects;
using Xunit;

namespace Tests.Core.Services;

public class PublisherServiceTest
{
    private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;
    
    public PublisherServiceTest()
    {
        var publisherRepositoryMock = Substitute.For<IPublisherRepository>();
        
        publisherRepositoryMock.GetAll().Returns(PublisherTestData.GetFakePublishers());
        publisherRepositoryMock.GetById(1).Returns(PublisherTestData.GetFakePublishers().First());
        
        _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
            .AddUnitOfWork()
            .AddAutoMapper()
            .AddRepositories()
            .AddScoped(publisherRepositoryMock)
            .AddServices()
            .AddMockedDbContext();
    }
    
    [Fact]
    public async Task GetAllPublishers_ReturnsPublishers()
    {
        // Arrange
        var publishers = PublisherTestData.GetFakePublishers().ToList();
        var publishersIds = publishers.Select(p => p.Id).ToList();
        
        var serviceProvider = _serviceProviderBuilder.Create();
        
        using var scope = serviceProvider.CreateScope();
        var publisherService = scope.ServiceProvider.GetRequiredService<PublisherService>();
        
        // Act
        var result = (await publisherService.GetAll()).ToList();
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(publishers.Count, result.Count);
        Assert.All(result, publisherSummary => Assert.Contains(publisherSummary.Id, publishersIds));
    }
    
    [Fact]
    public async Task GetPublisherById_ReturnsPublisher()
    {
        // Arrange
        var publisher = PublisherTestData.GetFakePublishers().First();
        
        var serviceProvider = _serviceProviderBuilder.Create();
        
        using var scope = serviceProvider.CreateScope();
        var publisherService = scope.ServiceProvider.GetRequiredService<PublisherService>();
        
        // Act
        var result = await publisherService.GetById(publisher.Id);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(publisher.Id, result.Id);
        Assert.Equal(publisher.Name, result.Name);
    }
    
    [Fact]
    public async Task CreatePublisher_ReturnsPublisher()
    {
        // Arrange
        var publisherInputDto = PublisherTestData.GetFakePublisherInputDto();
        
        var serviceProvider = _serviceProviderBuilder.Create();
        
        using var scope = serviceProvider.CreateScope();
        var publisherService = scope.ServiceProvider.GetRequiredService<PublisherService>();
        
        // Act
        var result = await publisherService.Create(publisherInputDto);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(publisherInputDto.Name, result.Name);
    }
    
    [Fact]
    public async Task UpdatePublisher_ReturnsPublisher()
    {
        // Arrange
        var publisher = PublisherTestData.GetFakePublishers().First();
        var publisherInputDto = PublisherTestData.GetFakePublisherInputDto();
        
        var serviceProvider = _serviceProviderBuilder.Create();
        
        using var scope = serviceProvider.CreateScope();
        var publisherService = scope.ServiceProvider.GetRequiredService<PublisherService>();
        
        // Act
        var result = await publisherService.Update(publisherInputDto, publisher.Id);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(publisherInputDto.Name, result.Name);
    }
}