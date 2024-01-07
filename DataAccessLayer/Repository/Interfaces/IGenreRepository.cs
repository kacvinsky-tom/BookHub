using DataAccessLayer.Entity;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Repository.Interfaces;

public interface IGenreRepository : IGenericRepository<Genre>
{
    public Task<Genre?> GetByIdWithRelations(int id);
    public Task<PaginationObject<Genre>> GetPaginatedBySearchQuery(
        string query,
        int page,
        int pageSize
    );
}
