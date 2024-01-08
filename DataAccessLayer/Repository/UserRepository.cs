using Core.Helpers;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BookHubDbContext context)
        : base(context) { }

    public async Task<User?> GetByIdWithRelations(int id)
    {
        return await Context
            .Users.Include(u => u.Reviews)
            .Include(u => u.Orders)
            .Include(u => u.CartItems)
            .ThenInclude(ci => ci.Book)
            .Include(u => u.WishLists)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await Context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<IEnumerable<SimpleListResult>> GetSimpleList(
        IEnumerable<Ordering<User>>? order = null
    )
    {
        var query = Context.Users.AsQueryable();

        if (order != null)
        {
            query = ApplyOrderingExpressions(order, query);
        }

        return await query
            .Select(
                u =>
                    new SimpleListResult
                    {
                        Id = u.Id.ToString(),
                        Value = u.FirstName + " " + u.LastName + " (" + u.Username + ")"
                    }
            )
            .ToListAsync();
    }
}
