using DataAccessLayer.Entity;
using DataAccessLayer.Extensions;
using DataAccessLayer.Filter;
using DataAccessLayer.Helpers;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(BookHubDbContext context)
        : base(context) { }

    public override IQueryable<Book> GetBasicQuery()
    {
        return _context
            .Books
            // .Include(book => book.Genres)
            .Include(book => book.BookGenres)
            .ThenInclude(bg => bg.Genre)
            .Include(book => book.Reviews)
            .ThenInclude(review => review.User)
            .Include(book => book.Publisher)
            .Include(book => book.BookAuthors)
            .Include(book => book.Authors)
            .Where(book => !book.IsDeleted);
    }

    public async Task<PaginationObject<Book>> GetPaginatedBySearchQuery(
        string query,
        int page,
        int pageSize
    )
    {
        var booksFiltered = GetBasicQuery().Where(b => b.Title.ToUpper().Contains(query));
        return await GetPaginated(page, pageSize, null, false, booksFiltered);
    }

    public async Task<IEnumerable<Book>> GetWithRelations(BookFilter? filterInput = null)
    {
        if (filterInput == null)
        {
            return await GetBasicQuery().ToListAsync();
        }

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
