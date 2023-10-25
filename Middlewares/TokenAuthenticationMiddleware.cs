using Microsoft.AspNetCore.Mvc;

namespace BookHub.Middlewares;

public class TokenAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public TokenAuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var hardcodedToken = _configuration.GetValue<string>("APIAuthorization:BearerToken");


        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Unauthorized. Missing authorization token.");
            return;
        }

        var requestToken = context.Request.Headers.Authorization.ToString();

        if (requestToken != hardcodedToken)
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Unauthorized. Invalid or expired authorization token.");
            return;
        }

        await _next(context);
    }
    
}

public static class TokenAuthenticationMiddlewareExtensions
{
    public static IApplicationBuilder UseTokenAuthenticationMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TokenAuthenticationMiddleware>();
    }
}