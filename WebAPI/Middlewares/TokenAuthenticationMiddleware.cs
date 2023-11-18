namespace WebAPI.Middlewares;

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
        var responseAuthorization = context.Request.Headers.Authorization.ToString().Split(" ");

        var responseAuthorizationScheme = responseAuthorization.FirstOrDefault();
        var responseAuthorizationParam = responseAuthorization.LastOrDefault();

        if (responseAuthorizationScheme != "Bearer")
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "text/plain";
            await context
                .Response
                .WriteAsync("Unauthorized. Missing or unsupported authorization.");
            return;
        }

        var hardcodedToken = _configuration.GetValue<string>("APIAuthorization:BearerToken");

        if (responseAuthorizationParam != hardcodedToken)
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "text/plain";
            await context
                .Response
                .WriteAsync("Unauthorized. Invalid or expired authorization token.");
            return;
        }

        await _next(context);
    }
}
