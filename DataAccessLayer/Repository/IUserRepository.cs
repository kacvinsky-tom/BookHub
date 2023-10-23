using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User?> GetByIdWithRelations(int id);
}