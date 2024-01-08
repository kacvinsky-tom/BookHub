using Core.Helpers;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IGenreRepository : IGenericRepository<Genre>
{
    public Task<Genre?> GetByIdWithRelations(int id);

    public Task<IEnumerable<SimpleListResult>> GetSimpleList(
        IEnumerable<Ordering<Genre>>? order = null
    );
}
