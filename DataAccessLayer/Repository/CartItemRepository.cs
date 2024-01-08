using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(BookHubDbContext context)
        : base(context) { }

    public override IQueryable<CartItem> GetBasicQuery()
    {
        return Context
            .CartItems.Include(r => r.User)
            .Include(r => r.Book)
            .ThenInclude(b => b.Authors)
            .Include(r => r.Book)
            .ThenInclude(b => b.Genres);
    }

    public async Task<CartItem?> GetByIdWithRelations(int id)
    {
        return await Context
            .CartItems.Include(r => r.User)
            .Include(r => r.Book)
            .ThenInclude(b => b.Authors)
            .Include(r => r.Book)
            .ThenInclude(b => b.Genres)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<CartItem>> GetAllWithRelations()
    {
        return await Context.CartItems.Include(r => r.User).Include(r => r.Book).ToListAsync();
    }

    public async Task<IEnumerable<CartItem>> GetByUserIdWithRelations(int userId)
    {
        return await GetBasicQuery().Where(r => r.UserId == userId).ToListAsync();
    }
}
