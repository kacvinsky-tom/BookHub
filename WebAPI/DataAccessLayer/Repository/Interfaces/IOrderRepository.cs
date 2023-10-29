using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<Order?> GetByIdWithRelations(int id);
    public Task<List<Order>> GetAllWithRelations();
}