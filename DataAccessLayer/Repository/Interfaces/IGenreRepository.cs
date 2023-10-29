using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository.Interfaces;

public interface IGenreRepository : IGenericRepository<Genre>
{ 
    public Task<Genre?> GetByIdWithRelations(int id);
}