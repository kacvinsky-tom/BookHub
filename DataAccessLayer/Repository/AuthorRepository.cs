using DataAccessLayer.Entity;
using DataAccessLayer.Helpers;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(BookHubDbContext context)
        : base(context) { }

    public override IQueryable<Author> GetBasicQuery()
    {
        return _context.Authors.Include(a => a.Books);
    }

    public async Task<Author?> GetByIdWithRelations(int id)
    {
        return await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<PaginationObject<Author>> GetPaginatedBySearchQuery(
        string query,
        int page,
        int pageSize
    )
    {
        var authorsFiltered = GetBasicQuery()
            .Where(
                a => a.FirstName.ToUpper().Contains(query) || a.LastName.ToUpper().Contains(query)
            );
        return await GetPaginated(page, pageSize, null, false, authorsFiltered);
    }
}
