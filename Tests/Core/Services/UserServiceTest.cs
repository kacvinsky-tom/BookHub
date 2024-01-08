using Core.Services;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Tests.Utilities.Data;
using Tests.Utilities.MockedObjects;
using Xunit;

namespace Tests.Core.Services;

public class UserServiceTest
{
    private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;

    public UserServiceTest()
    {
        var userRepositoryMock = Substitute.For<IUserRepository>();

        userRepositoryMock.GetAll().Returns(UserTestData.GetFakeUsers());
        userRepositoryMock.GetById(1).Returns(UserTestData.GetFakeUsers().First());
        userRepositoryMock.GetByIdWithRelations(1).Returns(UserTestData.GetFakeUsers().First());

        _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
            .AddUnitOfWork()
            .AddAutoMapper()
            .AddRepositories()
            .AddScoped(userRepositoryMock)
            .AddServices()
            .AddMockedDbContext();
    }

    [Fact]
    public async Task GetAllUsers_ReturnsUsers()
    {
        // Arrange
        var users = UserTestData.GetFakeUsers().ToList();
        var usersIds = users.Select(u => u.Id).ToList();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var userService = scope.ServiceProvider.GetRequiredService<UserService>();

        // Act
        var result = (await userService.GetAll()).ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(users.Count, result.Count);
        Assert.All(result, userSummary => Assert.Contains(userSummary.Id, usersIds));
    }

    [Fact]
    public async Task GetUserById_ReturnsUser()
    {
        // Arrange
        var user = UserTestData.GetFakeUsers().First();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var userService = scope.ServiceProvider.GetRequiredService<UserService>();

        // Act
        var result = await userService.GetById(user.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(user.Id, result.Id);
    }

    [Fact]
    public async Task CreateUser_ReturnsUser()
    {
        // Arrange
        var user = UserTestData.GetFakeUserInputDto();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var userService = scope.ServiceProvider.GetRequiredService<UserService>();

        // Act
        var result = await userService.Create(user);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(user.Email, result.Email);
    }

    [Fact]
    public async Task UpdateUser_ReturnsUser()
    {
        // Arrange
        var user = UserTestData.GetFakeUserInputDto();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var userService = scope.ServiceProvider.GetRequiredService<UserService>();

        // Act
        var result = await userService.Update(user, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(user.Email, result.Email);
    }

    [Fact]
    public async Task DeleteUser_Success()
    {
        // Arrange
        var user = UserTestData.GetFakeUsers().First();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var userService = scope.ServiceProvider.GetRequiredService<UserService>();

        // Act
        await userService.Delete(user.Id);
    }
}
