using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IWishListRepository : IGenericRepository<WishList>
{
    public Task<WishList?> GetByIdWithRelations(int id);
    public Task<IEnumerable<WishList>> GetByBookId(int bookId, bool containsBook = true);

    public Task<IEnumerable<WishList>> GetByBookIdAndUserName(int bookId, string userName,
        bool containsBook = true);

    public Task<IEnumerable<WishList>> GetAllForUser(int userId);
}
