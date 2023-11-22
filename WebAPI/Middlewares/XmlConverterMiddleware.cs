using Core.Services;
using WebAPI.Exception;

namespace WebAPI.Middlewares;

public class XmlResponseMiddleware
{
    private readonly RequestDelegate _next;

    public XmlResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var queryParameters = context.Request.Query;

        if (
            !queryParameters.ContainsKey("responseFormat")
            || queryParameters["responseFormat"] != "xml"
        )
        {
            await _next(context);
            return;
        }

        if (context.Response.ContentType != "application/json")
        {
            throw new XmlConverterMiddlewareException("Response content type is not JSON.");
        }

        await ConvertResponse(context);
    }

    private async Task ConvertResponse(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await _next(context);

        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();

        // Modify the response here
        var modifiedResponse = ModifyResponseString(responseBodyText);

        context.Response.Body = originalBodyStream;
        context.Response.ContentType = "application/xml"; // Set the content type based on your response
        await context.Response.WriteAsync(modifiedResponse);
    }

    private string ModifyResponseString(string originalResponse)
    {
        var xml = XmlService.ConvertJsonToXml(originalResponse);

        if (xml == null)
        {
            throw new XmlConverterMiddlewareException("Unable to convert JSON response to XML.");
        }

        return xml;
    }
}
