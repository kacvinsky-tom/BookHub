using DataAccessLayer.Entity;
using DataAccessLayer.Filter;
using DataAccessLayer.Helpers;

namespace DataAccessLayer.Repository.Interfaces;

public interface IBookRepository : IGenericRepository<Book>
{
    public Task<IEnumerable<Book>> GetWithRelations(BookFilter? filterInput = null);

    public Task<Book?> GetByIdWithRelations(int id);
    public Task<PaginationObject<Book>> GetPaginatedBySearchQuery(
        string query,
        int page,
        int pageSize
    );
}
