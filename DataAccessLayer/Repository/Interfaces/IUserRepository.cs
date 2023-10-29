using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User?> GetByIdWithRelations(int id);
}