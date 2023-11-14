namespace WebAPI.Exception;

public class NotFoundException : System.Exception
{
    public readonly int Id;
    
    public readonly string EntityName;

    protected NotFoundException(int id, string entityName)
    {
        Id = id;
        EntityName = entityName;
    }
}