using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository;

public interface IBookRepository : IGenericRepository<Book>
{
    public Task<IEnumerable<Book>> GetWithRelations();
}