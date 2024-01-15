using DataAccessLayer.Entity;

namespace DataAccessLayer.Extensions;

public static class AuthorDbSetExtensions
{
    public static IQueryable<Author> WhereName(this IQueryable<Author> query, string? name)
    {
        if (name == null)
        {
            return query;
        }

        return query.Where(a =>
            a.FirstName.ToUpper().Contains(name.ToUpper())
            || a.LastName.ToUpper().Contains(name.ToUpper())
        );
    }
}
