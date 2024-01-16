using WebAPI.Middlewares;

namespace WebAPI.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseTokenAuthenticationMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<TokenAuthenticationMiddleware>();
    }

    public static void UseXmlResponseMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<XmlResponseMiddleware>();
    }
}
