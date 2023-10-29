using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository.Interfaces;

public interface ICartItemRepository : IGenericRepository<CartItem>
{
    public Task<CartItem?> GetByIdWithRelations(int id);
    public Task<List<CartItem>> GetAllWithRelations();
}