using BookHub.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataAccessLayer.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(BookHubDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Book>> GetWithRelations()
    {
        return await _context.Books
            .Include(book => book.Genres)
            .Include(book => book.Reviews)
            .ThenInclude(review => review.User)
            .Include(book => book.Author)
            .Where(book => !book.IsDeleted)
            .ToListAsync();
    }

    public async Task<Book?> GetByIdWithRelations(int id)
    {
        return await _context.Books
            .Include(book => book.Genres)
            .Include(book => book.Reviews)
            .ThenInclude(review => review.User)
            .Include(book => book.Author)
            .Where(book => !book.IsDeleted)
            .FirstOrDefaultAsync(book => book.Id == id);
    }
}