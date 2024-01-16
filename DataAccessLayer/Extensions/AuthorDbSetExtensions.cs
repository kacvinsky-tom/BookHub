using DataAccessLayer.Entity;

namespace DataAccessLayer.Extensions;

public static class AuthorDbSetExtensions
{
    public static IQueryable<Author> WhereName(this IQueryable<Author> query, string? searchQuery)
    {
        if (searchQuery == null)
        {
            return query;
        }

        var normalizedSearchQuery = searchQuery.ToUpper();

        return query.Where(a =>
            normalizedSearchQuery.Contains(a.FirstName.ToUpper())
            || normalizedSearchQuery.Contains(a.LastName.ToUpper())
            || a.FirstName.ToUpper().Contains(normalizedSearchQuery)
            || a.LastName.ToUpper().Contains(normalizedSearchQuery)
        );
    }
}
