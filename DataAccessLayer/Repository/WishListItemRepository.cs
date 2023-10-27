using BookHub.DataAccessLayer.Entity;
using BookHub.DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataAccessLayer.Repository;

public class WishListItemRepository : GenericRepository<WishListItem>, IWishListItemRepository
{
    public WishListItemRepository(BookHubDbContext context) : base(context)
    {
    }
    
    public async Task<WishListItem?> GetByIdWithRelations(int id)
    {
        return await _context.WishListItems
            .Include(w => w.Book)
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<List<WishListItem>> GetAllWithRelations()
    {
        return await _context.WishListItems
            .Include(w => w.Book)
            .ToListAsync();
    }
}