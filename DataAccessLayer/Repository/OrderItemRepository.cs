using BookHub.DataAccessLayer.Entity;
using BookHub.DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataAccessLayer.Repository;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(BookHubDbContext context) : base(context)
    {
    }
    public async Task<List<OrderItem>> GetAllWithRelations()
    {
        return await _context.OrderItems
            .Include(oi => oi.Order)
            .ThenInclude(o => o.User)
            .Include(oi => oi.Book)
            .ToListAsync();
    }
    public async Task<OrderItem?> GetByIdWithRelations(int id)
    {
        return await _context.OrderItems
            .Include(oi => oi.Order)
            .ThenInclude(o => o.User)
            .Include(oi => oi.Book)
            .FirstOrDefaultAsync(w => w.Id == id);
    }
}