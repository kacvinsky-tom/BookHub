using Core.Helpers;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
{
    public PublisherRepository(BookHubDbContext context)
        : base(context) { }
    
    public async Task<IEnumerable<SimpleListResult>> GetSimpleList(IEnumerable<Ordering<Publisher>>? order = null)
    {
        var query = Context.Publishers.AsQueryable();
        
        if (order != null)
        {
            query = ApplyOrderingExpressions(order, query);
        }

        return await query.Select(p => new SimpleListResult
        {
            Id = p.Id.ToString(),
            Value = p.Name
        }).ToListAsync();
    }
}
