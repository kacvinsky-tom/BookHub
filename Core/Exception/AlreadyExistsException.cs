namespace Core.Exception;

public class AlreadyExistsException : System.Exception
{
    public AlreadyExistsException(string message = "Entity already exists")
        : base(message) { }
}
