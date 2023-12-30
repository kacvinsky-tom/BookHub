using Microsoft.AspNetCore.Builder;

namespace LoggingMiddleware.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseLoggingMiddleware(this IApplicationBuilder builder, string logSource)
    {
        builder.UseMiddleware<LoggingMiddleware>(logSource);
    }
}
