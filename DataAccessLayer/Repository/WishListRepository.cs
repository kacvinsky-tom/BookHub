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

    public async Task<IEnumerable<WishList>> GetByBookId(int bookId, bool containsBook = true)
    {
        if (containsBook)
        {
            return await GetBasicQuery()
                .Where(w => w.WishListItems.Any(wli => wli.BookId == bookId))
                .ToListAsync();
        }

        return await GetBasicQuery()
            .Where(w => w.WishListItems.All(wli => wli.BookId != bookId))
            .ToListAsync();
    }

    public async Task<IEnumerable<WishList>> GetByBookIdAndUserName(int bookId, string userName,
        bool containsBook = true)
    {
        if (containsBook)
        {
            return await GetBasicQuery()
                .Where(w => w.User.Username == userName)
                .Where(w => w.WishListItems.Any(wli => wli.BookId == bookId))
                .ToListAsync();
        }

        return await GetBasicQuery()
            .Where(w => w.User.Username == userName)
            .Where(w => w.WishListItems.All(wli => wli.BookId != bookId))
            .ToListAsync();
    }

    public async Task<IEnumerable<WishList>> GetAllForUser(int userId)
    {
        return await GetBasicQuery().Where(w => w.UserId == userId).ToListAsync();
    }
}
