using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    public Task<OrderItem?> GetByIdWithRelations(int id);
    public Task<IEnumerable<OrderItem>> GetAllWithRelations();
}
