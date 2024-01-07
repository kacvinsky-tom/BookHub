using System.Linq.Expressions;
using Core.Helpers;
using DataAccessLayer.Filter;
using DataAccessLayer.Helpers;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    protected readonly BookHubDbContext _context;

    public GenericRepository(BookHubDbContext context)
    {
        _context = context;
    }

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task AddRange(IEnumerable<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
    }

    public async Task<PaginationObject<T>> GetPaginated(
        int page,
        int pageSize,
        Expression<Func<T, IComparable>>? orderingExpression = null,
        bool reverseOrder = false,
        IQueryable<T>? query = null
    )
    {
        query ??= GetBasicQuery();

        if (orderingExpression != null)
        {
            query = reverseOrder
                ? query.OrderByDescending(orderingExpression)
                : query.OrderBy(orderingExpression);
        }

        return await PaginationObject(page, pageSize, query);
    }

    public async Task<PaginationObject<T>> GetPaginatedFiltered(
        IFilter filter,
        int page,
        int pageSize,
        Expression<Func<T, bool>>? orderingExpression = null,
        bool reverseOrder = false
    /* TODO:
     * toto by chtelo v ramci vypracovavani Issue #31 "Develop a Search feature for Products, Categories, Manufacturers"
     * refaktorovat, funkcionalitu sjednotit s GetAllOrdered, potencialne vsechny Get* metody sjednotit
     */
    )
    {
        var query = GetFilteredQuery(filter);

        if (orderingExpression != null)
        {
            query = reverseOrder
                ? query.OrderByDescending(orderingExpression)
                : query.OrderBy(orderingExpression);
        }

        return await PaginationObject(page, pageSize, query);
    }

    private static async Task<PaginationObject<T>> PaginationObject(
        int page,
        int pageSize,
        IQueryable<T> query
    )
    {
        return new PaginationObject<T>()
        {
            Items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(),
            Page = page,
            TotalItems = query.Count(),
            TotalPages = (int)Math.Ceiling(query.Count() / (double)pageSize)
        };
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().Where(expression).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllOrdered(IEnumerable<Ordering<T>> orderingExpressions)
    {
        var exprEnumerated = orderingExpressions.ToList();
        var first = exprEnumerated.First();
        var query = first.Reverse
            ? GetBasicQuery().OrderByDescending(first.Expression)
            : GetBasicQuery().OrderBy(first.Expression);

        query = exprEnumerated
            .Skip(1)
            .Aggregate(
                query,
                (current, expression) =>
                    expression.Reverse
                        ? current.ThenByDescending(expression.Expression)
                        : current.ThenBy(expression.Expression)
            );

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual IQueryable<T> GetBasicQuery()
    {
        return _context.Set<T>();
    }

    public virtual IQueryable<T> GetFilteredQuery(IFilter filter)
    {
        return _context.Set<T>();
    }

    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
}
