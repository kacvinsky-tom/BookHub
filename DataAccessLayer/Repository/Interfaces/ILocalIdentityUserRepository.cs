using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface ILocalIdentityUserRepository : IGenericRepository<LocalIdentityUser>
{
    public Task<LocalIdentityUser?> GetById(string id);
}
