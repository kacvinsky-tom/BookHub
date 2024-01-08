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
}
