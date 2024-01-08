namespace WebAPI.Exception;

public class XmlConverterMiddlewareException : System.Exception
{
    public XmlConverterMiddlewareException(string message)
        : base(message) { }
}
