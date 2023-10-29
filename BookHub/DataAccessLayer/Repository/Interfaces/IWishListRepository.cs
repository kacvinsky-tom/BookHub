using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository.Interfaces;

public interface IWishListRepository : IGenericRepository<WishList>
{
    public Task<WishList?> GetByIdWithRelations(int id);
}