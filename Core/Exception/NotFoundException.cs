namespace Core.Exception;

public class NotFoundException<TId> : System.Exception
{
    public readonly TId Id;

    public readonly string EntityName;

    protected NotFoundException(TId id, string entityName)
    {
        Id = id;
        EntityName = entityName;
    }
}

public class NotFoundException : NotFoundException<int>
{
    public NotFoundException(int id, string entityName)
        : base(id, entityName) { }
}
