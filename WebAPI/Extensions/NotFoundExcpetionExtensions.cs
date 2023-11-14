using WebAPI.Exception;

namespace WebAPI.Extensions;

public static class NotFoundExceptionExtensions
{
    public static string GetApiMessage(this NotFoundException exception)
    {
        return $"Entity of type {exception.EntityName} with ID {exception.Id} not found.";
    }
}