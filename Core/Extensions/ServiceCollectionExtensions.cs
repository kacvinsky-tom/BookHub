using Core.Services;
using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

    public static IServiceCollection AddPostgreDbContextFactory(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        return services.AddDbContextFactory<BookHubDbContext>(options =>
        {
            var connectionString = configuration.GetValue<string>(
                "ConnectionStrings:LocalPostgresConnection"
            );

            options.UseNpgsql(connectionString, x => x.MigrationsAssembly("Migrations.Postgre"));
        });
    }

    public static IServiceCollection AddSqliteDbContextFactory(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        return services.AddDbContextFactory<BookHubDbContext>(options =>
        {
            const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;

            var dbFileName = configuration.GetValue<string>("ConnectionStrings:SQLiteFileName");
            var dbPath = Path.Join(Environment.GetFolderPath(folder), dbFileName);

            options.UseSqlite(
                $"Data Source={dbPath}",
                x => x.MigrationsAssembly("Migrations.Sqlite")
            );
        });
    }

    public static void AddMemoryCacheWithConfiguration(this IServiceCollection services)
    {
        services.AddMemoryCache(options =>
        {
            options.ExpirationScanFrequency = TimeSpan.FromSeconds(5);
        });
    }
}
