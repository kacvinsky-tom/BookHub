using System.Linq.Expressions;
using Core.Helpers;
using DataAccessLayer.Entity;
using DataAccessLayer.Filter;
using DataAccessLayer.Helpers;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IGenericRepository<T>
    where T : class
{
    public IQueryable<T> GetBasicQuery();
    public IQueryable<T> GetFilteredQuery(IFilter filter);

    public Task<T?> GetById(int id);
    public Task<IEnumerable<T>> GetAll();

    public Task<IEnumerable<T>> GetAllOrdered(IEnumerable<Ordering<T>> orderingExpressions);

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
