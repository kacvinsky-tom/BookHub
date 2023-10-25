namespace BookHub.Middlewares;

public class TokenAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    
    public TokenAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
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