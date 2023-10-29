using BookHub.API.InputType.Filter;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository.Interfaces;

public interface IBookRepository : IGenericRepository<Book>
{
    public Task<IEnumerable<Book>> GetWithRelations(BookFilterInput filterInput);

    public Task<Book?> GetByIdWithRelations(int id);
}