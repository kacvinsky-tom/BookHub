using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<Order?> GetByIdWithRelations(int id);
    public Task<List<Order>> GetAllWithRelations();
}