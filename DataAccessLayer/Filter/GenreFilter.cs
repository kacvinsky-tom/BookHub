using DataAccessLayer.Entity;

namespace DataAccessLayer.Filter;

public class GenreFilter : IFilter<Genre>
{
    public string? Name { get; set; }

    public IQueryable<Genre> Apply(IQueryable<Genre> query)
    {
        if (Name == null)
            return query;

        return query.Where(g => g.Name.ToUpper().Contains(Name!.ToUpper()));
    }
}
