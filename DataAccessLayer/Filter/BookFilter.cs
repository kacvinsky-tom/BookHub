using DataAccessLayer.Entity;
using DataAccessLayer.Extensions;

namespace DataAccessLayer.Filter;

public class BookFilter : IFilter<Book>
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? PriceFrom { get; set; }

    public int? PriceTo { get; set; }

    public IEnumerable<int>? GenreIds { get; set; }

    public string? AuthorName { get; set; }

    public string? PublisherName { get; set; }
    
    public string? FullTextSearch { get; set; }
    
    public IQueryable<Book> Apply(IQueryable<Book> query)
    {
        return query.WhereTitle(Title)
            .WhereDescription(Description)
            .WherePriceIn(PriceFrom, PriceTo)
            .WhereGenreIds(GenreIds)
            .WhereAuthorName(AuthorName)
            .WherePublisherName(PublisherName)
            .WhereFulltext(FullTextSearch);
    }
}
