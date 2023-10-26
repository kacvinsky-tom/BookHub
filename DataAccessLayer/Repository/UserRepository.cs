using BookHub.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataAccessLayer.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BookHubDbContext context) : base(context)
    {
        
    }

    public async Task<User?> GetByIdWithRelations(int id)
    {
        return await _context.Users
            .Include(u => u.Reviews)
            .Include(u => u.Orders)
            .Include(u => u.CartItems)
            .Include(u => u.WishLists)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}