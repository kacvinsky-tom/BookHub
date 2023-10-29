using DataAccessLayer.Entity;
using DataAccessLayer.Filter;

namespace DataAccessLayer.Repository.Interfaces;

public interface IBookRepository : IGenericRepository<Book>
{
    public Task<IEnumerable<Book>> GetWithRelations(BookFilter filterInput);

    public Task<Book?> GetByIdWithRelations(int id);
}