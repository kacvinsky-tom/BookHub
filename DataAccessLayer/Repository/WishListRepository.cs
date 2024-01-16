using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class WishListRepository : GenericRepository<WishList>, IWishListRepository
{
    public WishListRepository(BookHubDbContext context)
        : base(context) { }

    public async Task<WishList?> GetByIdWithRelations(int id)
    {
        return await Context
            .WishLists.Include(w => w.WishListItems)
            .ThenInclude(wli => wli.Book)
            .ThenInclude(b => b.Authors)
            .FirstOrDefaultAsync(w => w.Id == id);
    }
}
