using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Services;

public static class XmlService
{
    public static string? ConvertJsonToXml(string jsonString)
    {
        try
        {
            var token = JToken.Parse(jsonString);

            var rootElementName = "Object";
        
            if (token is JArray)
            {
                jsonString = "{\"Object\":" + jsonString + "}";
                rootElementName = "List";
            }

            XNode? node = JsonConvert.DeserializeXNode(jsonString, rootElementName);
        
            var response = node?.ToString(SaveOptions.DisableFormatting);
        
            return response;
        }
        catch (JsonReaderException)
        {
            return null;
        }
    }
}