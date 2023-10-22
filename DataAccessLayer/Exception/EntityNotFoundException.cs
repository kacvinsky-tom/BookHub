namespace BookHub.DataAccessLayer.Exception;

public class EntityNotFoundException<TEntity> : System.Exception
{
    public EntityNotFoundException(int id) : base($"Entity of type {typeof(TEntity).Name} with ID {id} not found.")
    {
    }
}