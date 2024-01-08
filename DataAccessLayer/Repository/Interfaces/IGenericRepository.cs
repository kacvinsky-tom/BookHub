using System.Linq.Expressions;
using Core.Helpers;
using DataAccessLayer.Filter;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Repository.Interfaces;

public interface IGenericRepository<T>
    where T : class
{
    public IQueryable<T> GetBasicQuery();

    public Task<T?> GetById(int id);

    public Task<IEnumerable<T>> GetAll(
        IFilter<T>? filter = null,
        IEnumerable<Ordering<T>>? orderingExpressions = null
    );

    public Task<PaginationObject<T>> GetAllPaginated(
        int page,
        int pageSize,
        IFilter<T>? filter = null,
        IEnumerable<Ordering<T>>? order = null
    );

    public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    public Task Add(T entity);
    public Task AddRange(IEnumerable<T> entities);
    public void Remove(T entity);
    public void RemoveRange(IEnumerable<T> entities);
}
