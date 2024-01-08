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
        return Context.Authors.Include(a => a.Books);
    }

    public async Task<Author?> GetByIdWithRelations(int id)
    {
        return await Context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
    }
}
