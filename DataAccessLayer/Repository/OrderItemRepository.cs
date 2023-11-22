using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(BookHubDbContext context)
        : base(context) { }

    private IQueryable<OrderItem> GetBasicQuery()
    {
        return _context
            .OrderItems
            .Include(oi => oi.Order)
            .ThenInclude(o => o.User)
            .Include(oi => oi.Book);
    }

    public async Task<IEnumerable<OrderItem>> GetAllWithRelations()
    {
        return await GetBasicQuery().ToListAsync();
    }

    public async Task<OrderItem?> GetByIdWithRelations(int id)
    {
        return await GetBasicQuery().FirstOrDefaultAsync(w => w.Id == id);
    }
}
