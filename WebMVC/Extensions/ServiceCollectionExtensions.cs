using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace WebMVC.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContextWithConfiguration(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<BookHubDbContext>(options =>
        {
            var connectionString = configuration.GetValue<string>(
                "ConnectionStrings:MVCPostgresDatabase"
            );
            options.UseNpgsql(connectionString);
        });

        return services;
    }
}
