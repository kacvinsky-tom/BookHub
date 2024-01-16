using DataAccessLayer.Entity;

namespace DataAccessLayer.Extensions;

public static class BookDbSetExtensions
{
    public static IQueryable<Book> WhereTitle(this IQueryable<Book> query, string? title)
    {
        if (title == null)
        {
            return query;
        }

        return query.Where(book => book.Title.ToLower().Contains(title.ToLower()));
    }

    public static IQueryable<Book> WhereDescription(
        this IQueryable<Book> query,
        string? description
    )
    {
        if (description == null)
        {
            return query;
        }

        return query.Where(book => book.Description.ToLower().Contains(description.ToLower()));
    }

    public static IQueryable<Book> WherePriceIn(
        this IQueryable<Book> query,
        int? priceFrom,
        int? priceTo
    )
    {
        if (priceFrom != null)
        {
            query = query.Where(book => book.Price >= priceFrom);
        }

        if (priceTo != null)
        {
            query = query.Where(book => book.Price <= priceTo);
        }

        return query;
    }

    public static IQueryable<Book> WhereGenreIds(
        this IQueryable<Book> query,
        IEnumerable<int>? genreIds
    )
    {
        if (genreIds == null)
        {
            return query;
        }

        return query.Where(book => book.Genres.Any(genre => genreIds.Contains(genre.Id)));
    }

    public static IQueryable<Book> WhereAuthorName(this IQueryable<Book> query, string? authorName)
    {
        if (authorName == null)
        {
            return query;
        }

        return query.Where(
            book =>
                book.Authors.Any(
                    afn =>
                        afn.FirstName.ToLower().Contains(authorName.ToLower())
                        || book.Authors.Any(
                            aln => aln.LastName.ToLower().Contains(authorName.ToLower())
                        )
                )
        );
    }

    public static IQueryable<Book> WherePublisherName(
        this IQueryable<Book> query,
        string? publisherName
    )
    {
        if (publisherName == null)
        {
            return query;
        }

        return query.Where(book => book.Publisher.Name.ToLower().Contains(publisherName.ToLower()));
    }

    public static IQueryable<Book> WhereFulltext(this IQueryable<Book> query, string? search)
    {
        if (search == null)
        {
            return query;
        }

        return query.Where(
            book =>
                book.Title.ToLower().Contains(search.ToLower())
                || book.Description.ToLower().Contains(search.ToLower())
                || book.Authors.Any(
                    afn =>
                        afn.FirstName.ToLower().Contains(search.ToLower())
                        || book.Authors.Any(
                            aln => aln.LastName.ToLower().Contains(search.ToLower())
                        )
                )
                || book.Publisher.Name.ToLower().Contains(search.ToLower())
        );
    }
}
