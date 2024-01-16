using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Core.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private readonly ILogger<LoggingMiddleware> _logger;
    private readonly string _logSource;

    public LoggingMiddleware(
        RequestDelegate next,
        IConfiguration configuration,
        ILogger<LoggingMiddleware> logger,
        string logSource
    )
    {
        _next = next;
        _configuration = configuration;
        _logger = logger;
        _logSource = logSource;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation(
            _configuration.GetValue<bool>("Logging:RequestLogging:Detailed")
                ? FormatContextDataLong(context)
                : FormatContextDataShort(context)
        );

        await _next(context);
    }

    private string FormatContextDataShort(HttpContext context)
    {
        return $"{_logSource} | {DateTime.Now:yyyy-MM-dd HH:mm:ss} | {context.Connection.RemoteIpAddress}:{context.Connection.RemotePort}"
            + $" | {context.Request.Method} {context.Request.Path}";
    }

    private string FormatContextDataLong(HttpContext context)
    {
        var headers = string.Join(
            ";",
            context.Request.Headers.Select(header => $"{header.Key} : {header.Value}")
        );
        return $"{_logSource} | {DateTime.Now:yyyy-MM-dd HH:mm:ss} | {context.Connection.RemoteIpAddress}:{context.Connection.RemotePort}"
            + $" | {context.Request.Method} {context.Request.Path}"
            + $" | {headers}";
    }
}
