using Core.DTO.Input.CartItem;
using Core.Exception;
using Core.Services;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Tests.Utilities.Data;
using Tests.Utilities.MockedObjects;
using Xunit;

namespace Tests.Core.Services;

public class CartServiceTests
{
    private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;
    private readonly BookHubDbContext _mockedContext;

    public CartServiceTests()
    {
        var options = MockedDbContext.GenerateNewInMemoryDbContextOptions();
        _mockedContext = MockedDbContext.CreateFromOptions(options);

        var cartItemRepositoryMock = Substitute.For<ICartItemRepository>();

        cartItemRepositoryMock.GetAllWithRelations().Returns(CartItemTestData.GetFakeCartItems());
        cartItemRepositoryMock.GetById(1).Returns(CartItemTestData.GetFakeCartItems().First());
        cartItemRepositoryMock
            .GetByIdWithRelations(1)
            .Returns(CartItemTestData.GetFakeCartItems().First());

        var bookRepositoryMock = Substitute.For<IBookRepository>();

        bookRepositoryMock.GetById(1).Returns(CartItemTestData.GetFakeCartItemBooks().First());

        var userRepositoryMock = Substitute.For<IUserRepository>();
        userRepositoryMock.GetById(1).Returns(CartItemTestData.GetFakeCartItemUsers().First());

        _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
            .ConfigureIdentity()
            .AddLogging()
            .AddUnitOfWork()
            .AddAutoMapper()
            .AddRepositories()
            .AddScoped<ICartItemRepository>(cartItemRepositoryMock)
            .AddScoped<IBookRepository>(bookRepositoryMock)
            .AddScoped<IUserRepository>(userRepositoryMock)
            .AddServices()
            .AddMockedDbContext();
    }

    [Fact]
    public async Task GetAllCartItems_ReturnsCartItems()
    {
        // Arrange
        var cartItems = CartItemTestData.GetFakeCartItems().ToList();
        var cartItemsIds = cartItems.Select(c => c.Id).ToList();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var cartService = scope.ServiceProvider.GetRequiredService<CartService>();

        // Act
        var result = (await cartService.GetAllCartItems()).ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(cartItems.Count, result.Count);
        Assert.All(result, cartItemSummary => Assert.Contains(cartItemSummary.Id, cartItemsIds));
    }

    [Fact]
    public async Task GetCartItemById_ReturnsCartItem()
    {
        // Arrange
        var cartItem = CartItemTestData.GetFakeCartItems().First();

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var cartService = scope.ServiceProvider.GetRequiredService<CartService>();

        // Act
        var result = await cartService.GetCartItemById(cartItem.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(cartItem.Id, result.Id);
    }

    [Fact]
    public async Task CreateCartItem_Correct_DoesNotThrowAndReturnsCorrectItem()
    {
        // Arrange
        var cartItemCreateInputDto = new CartItemCreateInputDto()
        {
            BookId = 1,
            UserId = 1,
            Quantity = 2
        };

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var cartService = scope.ServiceProvider.GetRequiredService<CartService>();

        // Act
        var result = await cartService.CreateCartItem(cartItemCreateInputDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(cartItemCreateInputDto.BookId, result.Book.Id);
        Assert.Equal(cartItemCreateInputDto.UserId, result.User.Id);
        Assert.Equal(cartItemCreateInputDto.Quantity, result.Quantity);
    }

    [Fact]
    public async Task CreateCartItem_WrongUser_ThrowsCorrectException()
    {
        // Arrange
        var cartItemCreateInputDto = new CartItemCreateInputDto()
        {
            BookId = 1,
            UserId = 999,
            Quantity = 2
        };

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var cartService = scope.ServiceProvider.GetRequiredService<CartService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<User>>(
            () => cartService.CreateCartItem(cartItemCreateInputDto)
        );
    }

    [Fact]
    public async Task CreateCartItem_WrongBook_ThrowsCorrectException()
    {
        // Arrange
        var cartItemCreateInputDto = new CartItemCreateInputDto()
        {
            BookId = 999,
            UserId = 1,
            Quantity = 2
        };

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var cartService = scope.ServiceProvider.GetRequiredService<CartService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<Book>>(
            () => cartService.CreateCartItem(cartItemCreateInputDto)
        );
    }

    [Fact]
    public async Task UpdateCartItem_Correct_DoesNotThrowAndReturnsCorrectItem()
    {
        // Arrange
        var cartItemUpdateInputDto = new CartItemUpdateInputDto() { Quantity = 2 };

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var cartService = scope.ServiceProvider.GetRequiredService<CartService>();

        // Act
        var result = await cartService.UpdateCartItem(cartItemUpdateInputDto, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(cartItemUpdateInputDto.Quantity, result.Quantity);
    }

    [Fact]
    public async Task UpdateCartItem_WrongId_ThrowsCorrectException()
    {
        // Arrange
        var cartItemUpdateInputDto = new CartItemUpdateInputDto() { Quantity = 2 };

        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var cartService = scope.ServiceProvider.GetRequiredService<CartService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<CartItem>>(
            () => cartService.UpdateCartItem(cartItemUpdateInputDto, 999)
        );
    }

    [Fact]
    public async Task RemoveCartItem_Correct_DoesNotThrow()
    {
        // Arrange
        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var cartService = scope.ServiceProvider.GetRequiredService<CartService>();

        // Act & Assert
        await cartService.RemoveCartItem(1);
    }

    [Fact]
    public async Task RemoveCartItem_WrongId_ThrowsCorrectException()
    {
        // Arrange
        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var cartService = scope.ServiceProvider.GetRequiredService<CartService>();

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException<CartItem>>(
            () => cartService.RemoveCartItem(999)
        );
    }
}
