using BookHub.DataAccessLayer.Entity;

namespace BookHub.DataAccessLayer.Repository.Interfaces;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task<Author?> GetByIdWithRelations(int id);
}