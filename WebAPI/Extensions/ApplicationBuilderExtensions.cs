using WebAPI.Middlewares;

namespace WebAPI.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggingMiddleware>();
    }

    public static IApplicationBuilder UseTokenAuthenticationMiddleware(
        this IApplicationBuilder builder
    )
    {
        return builder.UseMiddleware<TokenAuthenticationMiddleware>();
    }
}
