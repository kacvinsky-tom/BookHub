using Core.Extensions;
using Core.Services;
using DataAccessLayer;
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI;

namespace Tests.Utilities.MockedObjects;

public class MockedDependencyInjectionBuilder
{
    private IServiceCollection _serviceCollection = new ServiceCollection();

    public MockedDependencyInjectionBuilder AddMockedDbContext()
    {
        _serviceCollection = _serviceCollection.AddDbContext<BookHubDbContext>(
            options => options.UseInMemoryDatabase(MockedDbContext.RandomDbName)
        );

        return this;
    }

    public MockedDependencyInjectionBuilder AddScoped<T>(T objectToRegister)
        where T : class
    {
        _serviceCollection = _serviceCollection.AddScoped<T>(_ => objectToRegister);

        return this;
    }

    public MockedDependencyInjectionBuilder AddRepositories()
    {
        _serviceCollection = _serviceCollection
            .AddScoped<IAuthorRepository, AuthorRepository>()
            .AddScoped<ILocalIdentityUserRepository, LocalIdentityUserRepository>()
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<ICartItemRepository, CartItemRepository>()
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddScoped<IOrderItemRepository, OrderItemRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IPublisherRepository, PublisherRepository>()
            .AddScoped<IReviewRepository, ReviewRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IVoucherRepository, VoucherRepository>()
            .AddScoped<IWishListRepository, WishListRepository>()
            .AddScoped<IWishListItemRepository, WishListItemRepository>()
            .AddScoped<IBookRepository, BookRepository>();

        return this;
    }

    public MockedDependencyInjectionBuilder AddServices()
    {
        _serviceCollection = _serviceCollection
            .AddScoped<BookService>()
            .AddScoped<VoucherService>()
            .AddScoped<LocalIdentityUserService>()
            .AddScoped<GenreService>()
            .AddScoped<CartService>()
            .AddScoped<AuthorService>()
            .AddScoped<PublisherService>()
            .AddScoped<OrderService>()
            .AddScoped<UserService>()
            .AddScoped<ReviewService>();

        return this;
    }
    
    public MockedDependencyInjectionBuilder ConfigureIdentity()
    {
        _serviceCollection = _serviceCollection.ConfigureIdentity();
        return this;
    }
    
    public MockedDependencyInjectionBuilder AddLogging()
    {
        _serviceCollection = _serviceCollection.AddLogging();
        return this;
    }
    
    public MockedDependencyInjectionBuilder AddUnitOfWork()
    {
        _serviceCollection = _serviceCollection.AddScoped<UnitOfWork>();

        return this;
    }

    public MockedDependencyInjectionBuilder AddAutoMapper()
    {
        _serviceCollection = _serviceCollection.AddAutoMapper(typeof(BookHubProfile));

        return this;
    }

    public ServiceProvider Create()
    {
        return _serviceCollection.BuildServiceProvider();
    }
}
