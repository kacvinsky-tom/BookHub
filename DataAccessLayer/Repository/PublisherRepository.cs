using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;

namespace DataAccessLayer.Repository;

public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
{
    public PublisherRepository(BookHubDbContext context) : base(context)
    {
    }
}