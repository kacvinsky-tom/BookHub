using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace WebAPI.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddSwaggerWithAuthentication(this IServiceCollection services)
    {
        return services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookHub API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Enter the API key without the prefix \"Bearer\"!",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
        });
    }
    
    public static void AddDbContextFactoryWithConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<BookHubDbContext>(options =>
        {
            const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            var dbFileName = configuration.GetValue<string>("ConnectionStrings:SQLiteFileName");
            var dbPath = Path.Join(Environment.GetFolderPath(folder), dbFileName);

            options.UseSqlite($"Data Source={dbPath}");
        });
    }

}
