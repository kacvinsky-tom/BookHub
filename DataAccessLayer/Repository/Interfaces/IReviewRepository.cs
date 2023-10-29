using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IReviewRepository : IGenericRepository<Review>
{
    public Task<Review?> GetByIdWithRelations(int id);
    public Task<List<Review>> GetAllWithRelations();
}