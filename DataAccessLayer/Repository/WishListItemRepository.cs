using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class WishListItemRepository : GenericRepository<WishListItem>, IWishListItemRepository
{
    public WishListItemRepository(BookHubDbContext context) : base(context)
    {
    }
    
    public async Task<WishListItem?> GetByIdWithRelations(int id)
    {
        return await _context.WishListItems
            .Include(w => w.Book)
            .ThenInclude(b => b.Authors)
            .Include(w => w.Book)
            .ThenInclude(b => b.Genres)
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<List<WishListItem>> GetAllWithRelations()
    {
        return await _context.WishListItems
            .Include(w => w.Book)
            .ThenInclude(b => b.Authors)
            .Include(w => w.Book)
            .ThenInclude(b => b.Genres)
            .ToListAsync();
    }
}