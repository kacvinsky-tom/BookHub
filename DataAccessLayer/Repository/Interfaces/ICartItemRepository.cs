using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface ICartItemRepository : IGenericRepository<CartItem>
{
    public Task<CartItem?> GetByIdWithRelations(int id);
    public Task<IEnumerable<CartItem>> GetAllWithRelations();
    public Task<IEnumerable<CartItem>> GetByUserIdWithRelations(int userId);
    public Task<CartItem?> GetByUserIdAndBookId(int userId, int bookId);
}
