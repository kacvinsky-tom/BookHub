using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(BookHubDbContext context) : base(context)
    {
    }
    
    public async Task<Author?> GetByIdWithRelations(int id)
    {
        return await _context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

}