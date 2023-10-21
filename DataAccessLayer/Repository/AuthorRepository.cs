using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(BookHubDbContext context) : base(context)
    {
    }
}