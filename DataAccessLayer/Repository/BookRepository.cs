using DataAccessLayer.Entity;
using DataAccessLayer.Extensions;
using DataAccessLayer.Filter;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(BookHubDbContext context)
        : base(context) { }

    private IQueryable<Book> GetBasicQuery()
    {
        return _context
            .Books
            .Include(book => book.Genres)
            .Include(book => book.Reviews)
            .ThenInclude(review => review.User)
            .Include(book => book.Publisher)
            .Include(book => book.Authors)
            .Where(book => !book.IsDeleted);
    }

    public async Task<IEnumerable<Book>> GetWithRelations(BookFilter filterInput)
    {
        var query = GetBasicQuery()
            .WhereTitle(filterInput.Title)
            .WhereDescription(filterInput.Description)
            .WherePriceIn(filterInput.PriceFrom, filterInput.PriceTo)
            .WhereGenreIds(filterInput.GenreIds)
            .WhereAuthorName(filterInput.AuthorName)
            .WherePublisherName(filterInput.PublisherName);

        return await query.ToListAsync();
    }

    public async Task<Book?> GetByIdWithRelations(int id)
    {
        return await GetBasicQuery().FirstOrDefaultAsync(book => book.Id == id);
    }
}
