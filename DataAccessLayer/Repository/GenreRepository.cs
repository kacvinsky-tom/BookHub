using Core.Helpers;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(BookHubDbContext context)
        : base(context) { }

    public async Task<Genre?> GetByIdWithRelations(int id)
    {
        return await Context.Genres.Include(g => g.Books).FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<IEnumerable<SimpleListResult>> GetSimpleList(
        IEnumerable<Ordering<Genre>>? order = null
    )
    {
        var query = Context.Genres.AsQueryable();

        if (order != null)
        {
            query = ApplyOrderingExpressions(order, query);
        }

        return await query
            .Select(g => new SimpleListResult { Id = g.Id.ToString(), Value = g.Name })
            .ToListAsync();
    }
}
