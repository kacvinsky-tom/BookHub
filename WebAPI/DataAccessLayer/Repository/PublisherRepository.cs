using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository;

public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
{
    public PublisherRepository(BookHubDbContext context) : base(context)
    {
    }
}