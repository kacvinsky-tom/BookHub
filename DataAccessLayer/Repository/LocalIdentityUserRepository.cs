using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class LocalIdentityUserRepository
    : GenericRepository<LocalIdentityUser>,
        ILocalIdentityUserRepository
{
    private readonly UserManager<LocalIdentityUser> _userManager;

    public LocalIdentityUserRepository(
        BookHubDbContext context,
        UserManager<LocalIdentityUser> userManager
    )
        : base(context)
    {
        _userManager = userManager;
    }

    public override IQueryable<LocalIdentityUser> GetBasicQuery()
    {
        return _userManager.Users.Include(u => u.User);
    }

    public async Task<LocalIdentityUser?> GetById(string id)
    {
        return await GetBasicQuery().FirstOrDefaultAsync(u => u.Id == id);
    }
}
