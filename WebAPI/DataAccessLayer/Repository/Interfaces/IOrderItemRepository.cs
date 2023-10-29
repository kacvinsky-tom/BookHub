using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository.Interfaces;

public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    public Task<OrderItem?> GetByIdWithRelations(int id);
    public Task<List<OrderItem>> GetAllWithRelations();
}