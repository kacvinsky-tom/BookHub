using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class WishListItemRepository : GenericRepository<WishListItem>, IWishListItemRepository
{
    public WishListItemRepository(BookHubDbContext context)
        : base(context) { }

    private IQueryable<WishListItem> GetBasicQuery()
    {
        return _context
            .WishListItems.Include(w => w.Book)
            .ThenInclude(b => b.Authors)
            .Include(w => w.Book)
            .ThenInclude(b => b.Genres);
    }

    public async Task<WishListItem?> GetByIdWithRelations(int id)
    {
        return await GetBasicQuery().FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<IEnumerable<WishListItem>> GetAllWithRelations()
    {
        return await GetBasicQuery().ToListAsync();
    }
}
