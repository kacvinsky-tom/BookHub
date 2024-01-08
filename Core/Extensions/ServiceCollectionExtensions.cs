using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBLServices(this IServiceCollection services)
    {
        return services
            .AddScoped<AuthorService>()
            .AddScoped<GenreService>()
            .AddScoped<BookService>()
            .AddScoped<CartService>()
            .AddScoped<OrderService>()
            .AddScoped<WishListService>()
            .AddScoped<ReviewService>()
            .AddScoped<UserService>()
            .AddScoped<PublisherService>()
            .AddScoped<VoucherService>();
    }
}
