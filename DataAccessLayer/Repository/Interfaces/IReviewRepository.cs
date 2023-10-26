using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository;

public interface IReviewRepository : IGenericRepository<Review>
{
    public Task<Review?> GetByIdWithRelations(int id);
    public Task<List<Review>> GetAllWithRelations();
}