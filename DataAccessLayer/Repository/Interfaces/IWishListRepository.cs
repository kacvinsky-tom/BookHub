using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IWishListRepository : IGenericRepository<WishList>
{
    public Task<WishList?> GetByIdWithRelations(int id);
}