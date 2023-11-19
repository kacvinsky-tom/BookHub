using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace WebAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddSwaggerWithAuthentication(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookHub API", Version = "v1" });

            c.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme
                {
                    Description = "Enter the API key without the prefix \"Bearer\"!",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                }
            );

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
                }
            );
        });
    }
    public static void AddDbContextFactoryWithConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<BookHubDbContext>(options =>
        {
            var connectionString = configuration.GetValue<string>("ConnectionStrings:LocalPostgresConnection");
            options.UseNpgsql(connectionString);
        });
    }
}
