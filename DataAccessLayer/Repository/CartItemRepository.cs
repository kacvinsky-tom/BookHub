using BookHub.DataAccessLayer.Entity;
using BookHub.DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataAccessLayer.Repository;

public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(BookHubDbContext context) : base(context)
    {
    }

    public async Task<CartItem?> GetByIdWithRelations(int id)
    {
        return await _context.CartItems
            .Include(r => r.User)
            .Include(r => r.Book)
            .ThenInclude(b => b.Authors )
            .Include(r => r.Book)
            .ThenInclude(b => b.Genres )
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<CartItem>> GetAllWithRelations()
    {
        return await _context.CartItems
            .Include(r => r.User)
            .Include(r => r.Book)
            .ToListAsync();
    }
}