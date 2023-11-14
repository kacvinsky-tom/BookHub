using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface ICartItemRepository : IGenericRepository<CartItem>
{
    public Task<CartItem?> GetByIdWithRelations(int id);
    public Task<IEnumerable<CartItem>> GetAllWithRelations();
}