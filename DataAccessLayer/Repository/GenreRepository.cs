using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(BookHubDbContext context) : base(context)
    {
    }
}