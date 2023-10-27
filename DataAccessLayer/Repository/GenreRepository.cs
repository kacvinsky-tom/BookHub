using BookHub.DataAccessLayer.Entity;
using BookHub.DataAccessLayer.Repository.Interfaces;

namespace BookHub.DataAccessLayer.Repository;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(BookHubDbContext context) : base(context)
    {
    }
}