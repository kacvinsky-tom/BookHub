using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IWishListItemRepository : IGenericRepository<WishListItem>
{
    public Task<WishListItem?> GetByIdWithRelations(int id);
    public Task<IEnumerable<WishListItem>> GetAllWithRelations();

    public Task<WishListItem?> GetByBookAndWishlistId(int bookId, int wishListId);
}
