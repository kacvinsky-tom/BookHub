using BookHub.DataAccessLayer.Entity;
using BookHub.DataAccessLayer.Repository.Interfaces;

namespace BookHub.DataAccessLayer.Repository;

public interface IVoucherRepository : IGenericRepository<Voucher>
{
    public Task<Voucher?> GetByIdWithRelations(int id);
    public Task<List<Voucher>> GetAllWithQuantities();
}