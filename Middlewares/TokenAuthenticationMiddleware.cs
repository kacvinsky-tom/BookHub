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
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized. Missing authorization token");
            return;
        }

        var tokenInput = context.Request.Headers.Authorization.ToString();

        if (tokenInput != _configuration.GetValue<string>("APIAuthorization:BearerToken"))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized. Invalid or expired authorization token");
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