using System.Linq.Expressions;
using DataAccessLayer.Filter;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Repository.Interfaces;

public interface IGenericRepository<T>
    where T : class
{
    public IQueryable<T> GetBasicQuery();
    public IQueryable<T> GetFilteredQuery(IFilter filter);

    public Task<T?> GetById(int id);
    public Task<IEnumerable<T>> GetAll();
    public Task<PaginationObject<T>> GetPaginated(
        int page,
        int pageSize,
        Expression<Func<T, IComparable>>? orderingExpression = null,
        bool reverseOrder = false
    );

    public Task<PaginationObject<T>> GetPaginatedFiltered(
        IFilter filter,
        int page,
        int pageSize,
        Expression<Func<T, bool>>? orderingExpression = null,
        bool reverseOrder = false
    );

    public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    public Task Add(T entity);
    public Task AddRange(IEnumerable<T> entities);
    public void Remove(T entity);
    public void RemoveRange(IEnumerable<T> entities);
}
