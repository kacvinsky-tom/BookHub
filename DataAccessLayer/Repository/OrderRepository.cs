using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(BookHubDbContext context)
        : base(context) { }

    public async Task<IEnumerable<Order>> GetAllWithRelations()
    {
        return await _context.Orders.Include(o => o.User).ToListAsync();
    }

    public async Task<Order?> GetByIdWithRelations(int id)
    {
        return await _context
            .Orders
            .Include(o => o.User)
            .Include(o => o.OrderItems)
            .Include(o => o.VoucherUsed)
            .FirstOrDefaultAsync(w => w.Id == id);
    }
}
