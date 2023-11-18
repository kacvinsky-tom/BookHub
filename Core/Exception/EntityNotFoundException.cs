namespace Core.Exception;

public class EntityNotFoundException<TEntity> : NotFoundException
{
    public EntityNotFoundException(int id)
        : base(id, typeof(TEntity).Name) { }
}
