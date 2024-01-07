using DataAccessLayer.Entity;
using DataAccessLayer.Helpers;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(BookHubDbContext context)
        : base(context) { }

    public async Task<Genre?> GetByIdWithRelations(int id)
    {
        return await _context.Genres.Include(g => g.Books).FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<PaginationObject<Genre>> GetPaginatedBySearchQuery(
        string query,
        int page,
        int pageSize
    )
    {
        var genresFiltered = GetBasicQuery().Where(g => g.Name.ToUpper().Contains(query));
        return await GetPaginated(page, pageSize, null, false, genresFiltered);
    }
}
