using Core.DTO.Input.Order;
using Core.Services;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Tests.Utilities.Data;
using Tests.Utilities.MockedObjects;
using Xunit;

namespace Tests.Core.Services;

public class OrderServiceTest
{
    private readonly MockedDependencyInjectionBuilder _serviceProviderBuilder;

    public OrderServiceTest()
    {
        var orderRepositoryMock = Substitute.For<IOrderRepository>();

        orderRepositoryMock.GetAll().Returns(OrderTestData.GetFakeOrders());
        orderRepositoryMock.GetAllWithRelations().Returns(OrderTestData.GetFakeOrders());
        orderRepositoryMock.GetById(1).Returns(OrderTestData.GetFakeOrders().First());
        orderRepositoryMock.GetByIdWithRelations(1).Returns(OrderTestData.GetFakeOrders().First());
        
        var userRepositoryMock = Substitute.For<IUserRepository>();
        userRepositoryMock.GetById(1).Returns(OrderTestData.GetFakeOrders().First().User);

        _serviceProviderBuilder = new MockedDependencyInjectionBuilder()
            .AddUnitOfWork()
            .AddAutoMapper()
            .AddRepositories()
            .AddScoped(orderRepositoryMock)
            .AddScoped(userRepositoryMock)
            .AddServices()
            .AddMockedDbContext();
    }

    [Fact]
    public async Task GetAllOrders_ReturnsOrders()
    {
        var orders = OrderTestData.GetFakeOrders().ToList();
        var ordersIds = orders.Select(o => o.Id).ToList();
        
        var serviceProvider = _serviceProviderBuilder.Create();
        
        using var scope = serviceProvider.CreateScope();
        var orderService = scope.ServiceProvider.GetRequiredService<OrderService>();
        
        var result = (await orderService.GetAll()).ToList();
        
        Assert.NotNull(result);
        Assert.Equal(orders.Count, result.Count);
        Assert.All(result, genreSummary => Assert.Contains(genreSummary.Id, ordersIds));
    }

    [Fact]
    public async Task GetOrderById_ReturnsOrder()
    {
        var order = OrderTestData.GetFakeOrders().First();
        
        var serviceProvider = _serviceProviderBuilder.Create();
        
        using var scope = serviceProvider.CreateScope();
        var orderService = scope.ServiceProvider.GetRequiredService<OrderService>();
        
        var result = await orderService.GetById(order.Id);
        
        Assert.NotNull(result);
        Assert.Equal(order.Id, result.Id);
    }

    [Fact]
    public async Task CreateOrder_ReturnsOrder()
    {
        var orderInputDto = new OrderCreateInputDto { UserId = 1 };
        var serviceProvider = _serviceProviderBuilder.Create();

        using var scope = serviceProvider.CreateScope();
        var orderService = scope.ServiceProvider.GetRequiredService<OrderService>();

        var result = await orderService.Create(orderInputDto);

        Assert.NotNull(result);
        Assert.Equal(orderInputDto.UserId, result.UserId);
    }
}