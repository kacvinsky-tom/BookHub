using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IVoucherRepository : IGenericRepository<Voucher>
{
    public Task<Voucher?> GetByIdWithRelations(int id);
    public Task<IEnumerable<Voucher>> GetAllWithQuantities();
}
