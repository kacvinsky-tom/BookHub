using BookHub.DataAccessLayer.Entity;
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
}