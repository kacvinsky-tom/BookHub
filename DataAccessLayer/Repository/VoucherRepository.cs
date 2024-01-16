using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class VoucherRepository : GenericRepository<Voucher>, IVoucherRepository
{
    public VoucherRepository(BookHubDbContext context)
        : base(context) { }

    public Task<Voucher?> GetByIdWithRelations(int id)
    {
        return Context.Vouchers.Include(v => v.Orders).FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<IEnumerable<Voucher>> GetAllWithQuantities()
    {
        return await Context
            .Vouchers.Include(v => v.UsedQuantity)
            .Include(v => v.IsUsable)
            .ToListAsync();
    }
}
