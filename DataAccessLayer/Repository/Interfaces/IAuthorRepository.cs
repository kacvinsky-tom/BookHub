using Core.Helpers;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task<Author?> GetByIdWithRelations(int id);

    public Task<IEnumerable<SimpleListResult>> GetSimpleList(IEnumerable<Ordering<Author>>? order = null);
}
