using Core.Helpers;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IPublisherRepository : IGenericRepository<Publisher>
{
    public Task<IEnumerable<SimpleListResult>> GetSimpleList(IEnumerable<Ordering<Publisher>>? order = null);
}
