using DataAccessLayer.Entity;
using DataAccessLayer.Extensions;

namespace DataAccessLayer.Filter;

public class AuthorFilter : IFilter<Author>
{
    public string? Name { get; set; }

    public IQueryable<Author> Apply(IQueryable<Author> query)
    {
        return query.WhereName(Name);
    }
}