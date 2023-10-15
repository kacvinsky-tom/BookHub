using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(BookHubDbContext context) : base(context)
    {
    }
}