namespace Core.Exception;

public class AlreadyExistsException<T> : System.Exception
{
    public AlreadyExistsException(string message = "Entity already exists")
        : base(message) { }
}
