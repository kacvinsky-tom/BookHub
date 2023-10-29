namespace BookHub.Middlewares;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private readonly ILogger<LoggingMiddleware> _logger;
    
    public LoggingMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _configuration = configuration;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation(_configuration.GetValue<bool>("Logging:RequestLogging:Detailed")
            ? FormatContextDataLong(context)
            : FormatContextDataShort(context));

        await _next(context);
    }

    private string FormatContextDataShort(HttpContext context)
    {
        return
            $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {context.Connection.RemoteIpAddress}:{context.Connection.RemotePort}" +
            $" | {context.Request.Method} {context.Request.Path}";
    }

    private string FormatContextDataLong(HttpContext context)
    {
        return
            $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {context.Connection.RemoteIpAddress}:{context.Connection.RemotePort}" +
            $" | {context.Request.Method} {context.Request.Path}" +
            $" | {string.Join(";", context.Request.Headers.Select(header => $"{header.Key} : {header.Value}"))}"; 
    }
}

public static class LoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggingMiddleware>();
    }
}