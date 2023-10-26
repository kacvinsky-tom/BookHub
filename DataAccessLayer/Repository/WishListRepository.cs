using BookHub.DataAccessLayer.Entity;
using BookHub.DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataAccessLayer.Repository;

public class WishListRepository : GenericRepository<WishList>, IWishListRepository
{
    public WishListRepository(BookHubDbContext context) : base(context)
    {
    }
    
    public async Task<WishList?> GetByIdWithRelations(int id)
    {
        return await _context.WishLists
            .Include(w => w.WishListItems)
            .FirstOrDefaultAsync(w => w.Id == id);
    }
}