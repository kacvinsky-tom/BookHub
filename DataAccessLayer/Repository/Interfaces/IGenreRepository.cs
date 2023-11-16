using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IGenreRepository : IGenericRepository<Genre>
{
    public Task<Genre?> GetByIdWithRelations(int id);
}
