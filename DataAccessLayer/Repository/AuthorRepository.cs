using Core.Helpers;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(BookHubDbContext context)
        : base(context) { }

    public override IQueryable<Author> GetBasicQuery()
    {
        return Context.Authors.Include(a => a.Books);
    }

    public async Task<Author?> GetByIdWithRelations(int id)
    {
        return await Context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<SimpleListResult>> GetSimpleList(
        IEnumerable<Ordering<Author>>? order = null
    )
    {
        var query = Context.Authors.AsQueryable();

        if (order != null)
        {
            query = ApplyOrderingExpressions(order, query);
        }

        return await query
            .Select(a => new SimpleListResult
            {
                Id = a.Id.ToString(),
                Value = a.LastName + " " + a.FirstName
            })
            .ToListAsync();
    }
}
