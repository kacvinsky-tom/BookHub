using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class VoucherRepository : GenericRepository<Voucher>, IVoucherRepository
{
    public VoucherRepository(BookHubDbContext context) : base(context)
    {
    }


    public Task<Voucher?> GetByIdWithRelations(int id)
    {
        return _context.Vouchers
            .Include(v => v.Orders)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public Task<List<Voucher>> GetAllWithQuantities()
    {
        return _context.Vouchers
            .Include(v => v.UsedQuantity)
            .Include(v => v.IsUsable)
            .ToListAsync();
    }
}