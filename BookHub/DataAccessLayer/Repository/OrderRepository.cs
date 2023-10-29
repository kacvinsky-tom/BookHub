using BookHub.DataAccessLayer.Entity;
using BookHub.DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataAccessLayer.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(BookHubDbContext context) : base(context)
    {
    }
    public async Task<List<Order>> GetAllWithRelations()
    {
        return await _context.Orders
            .Include(o => o.User)
            .ToListAsync();
    }
    public async Task<Order?> GetByIdWithRelations(int id)
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.OrderItems)
            .Include(o => o.VoucherUsed)
            .FirstOrDefaultAsync(w => w.Id == id);
    }
}