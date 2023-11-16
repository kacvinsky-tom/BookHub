using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task<Author?> GetByIdWithRelations(int id);
}
