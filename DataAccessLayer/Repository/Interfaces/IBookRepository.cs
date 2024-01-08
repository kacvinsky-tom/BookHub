using Core.Helpers;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IBookRepository : IGenericRepository<Book>
{
    public Task<Book?> GetByIdWithRelations(int id);

    public Task<IEnumerable<SimpleListResult>> GetSimpleList(
        IEnumerable<Ordering<Book>>? order = null
    );
}
