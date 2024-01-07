using DataAccessLayer.Entity;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Repository.Interfaces;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task<Author?> GetByIdWithRelations(int id);
    public Task<PaginationObject<Author>> GetPaginatedBySearchQuery(
        string query,
        int page,
        int pageSize
    );
}
