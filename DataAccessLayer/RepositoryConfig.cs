using DataAccessLayer.Repository;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

public static class RepositoryConfig
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVoucherRepository, VoucherRepository>();
        services.AddScoped<IWishListItemRepository, WishListItemRepository>();
        services.AddScoped<IWishListRepository, WishListRepository>();
    }
}
