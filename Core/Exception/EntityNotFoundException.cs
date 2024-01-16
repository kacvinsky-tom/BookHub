namespace Core.Exception;

public class EntityNotFoundException<TEntity, TId> : NotFoundException<TId>
{
    public EntityNotFoundException(TId id)
        : base(id, typeof(TEntity).Name) { }
}

public class EntityNotFoundException<TEntity> : EntityNotFoundException<TEntity, int>
{
    public EntityNotFoundException(int id)
        : base(id) { }
}
