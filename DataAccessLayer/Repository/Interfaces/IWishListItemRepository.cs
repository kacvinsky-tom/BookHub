using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository;

public interface IWishListItemRepository : IGenericRepository<WishListItem>
{
    public Task<WishListItem?> GetByIdWithRelations(int id);
    public Task<List<WishListItem>> GetAllWithRelations();
}