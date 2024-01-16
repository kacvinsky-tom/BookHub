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
    protected readonly BookHubDbContext Context;

    public GenericRepository(BookHubDbContext context)
    {
        Context = context;
    }

    public async Task Add(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
    }

    public async Task AddRange(IEnumerable<T> entities)
    {
        await Context.Set<T>().AddRangeAsync(entities);
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
        return await Context.Set<T>().Where(expression).ToListAsync();
    }

    public async Task<PaginationObject<T>> FindPaginated(
        Expression<Func<T, bool>> expression,
        int page,
        int pageSize
    )
    {
        var query = GetBasicQuery().Where(expression);

        return await PaginationObject(page, pageSize, query);
    }

    public async Task<IEnumerable<T>> GetAll(
        IFilter<T>? filter = null,
        IEnumerable<Ordering<T>>? orderingExpressions = null
    )
    {
        var query = GetBasicQuery();

        if (filter != null)
        {
            query = filter.Apply(query);
        }

        if (orderingExpressions != null)
        {
            query = ApplyOrderingExpressions(orderingExpressions, query);
        }

        return await query.ToListAsync();
    }

    public async Task<PaginationObject<T>> GetAllPaginated(
        int page,
        int pageSize,
        IFilter<T>? filter = null,
        IEnumerable<Ordering<T>>? order = null
    )
    {
        var query = GetBasicQuery();

        if (filter != null)
        {
            query = filter.Apply(query);
        }

        if (order != null)
        {
            query = ApplyOrderingExpressions(order, query);
        }

        return await PaginationObject(page, pageSize, query);
    }

    protected IOrderedQueryable<T> ApplyOrderingExpressions(
        IEnumerable<Ordering<T>> orderingExpressions,
        IQueryable<T> query
    )
    {
        var exprEnumerated = orderingExpressions.ToList();
        var first = exprEnumerated.First();

        var orderedQuery = first.Reverse
            ? query.OrderByDescending(first.Expression)
            : query.OrderBy(first.Expression);

        orderedQuery = exprEnumerated
            .Skip(1)
            .Aggregate(
                orderedQuery,
                (current, expression) =>
                    expression.Reverse
                        ? current.ThenByDescending(expression.Expression)
                        : current.ThenBy(expression.Expression)
            );

        return orderedQuery;
    }

    public virtual IQueryable<T> GetBasicQuery()
    {
        return Context.Set<T>();
    }

    public async Task<T?> GetById(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public void Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        Context.Set<T>().RemoveRange(entities);
    }
}
