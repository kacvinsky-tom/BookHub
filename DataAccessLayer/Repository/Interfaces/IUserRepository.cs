using Core.Helpers;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User?> GetByIdWithRelations(int id);
    public Task<User?> GetByUsername(string username);

    public Task<IEnumerable<SimpleListResult>> GetSimpleList(
        IEnumerable<Ordering<User>>? order = null
    );
}
