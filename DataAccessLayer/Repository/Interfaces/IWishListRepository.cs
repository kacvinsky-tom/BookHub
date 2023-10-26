using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository;

public interface IWishListRepository : IGenericRepository<WishList>
{
    public Task<WishList?> GetByIdWithRelations(int id);
}