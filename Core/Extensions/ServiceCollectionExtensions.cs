using Core.Services;
using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
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
            .AddScoped<LocalIdentityUserService>()
            .AddScoped<PublisherService>()
            .AddScoped<VoucherService>();
    }

    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<LocalIdentityUser, LocalIdentityRole>()
            .AddEntityFrameworkStores<BookHubDbContext>()
            .AddDefaultTokenProviders();
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 1;
        });
        return services;
    }
}
