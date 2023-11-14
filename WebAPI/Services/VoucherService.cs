using DataAccessLayer;
using DataAccessLayer.Entity;
using WebAPI.DTO.Input.Voucher;
using WebAPI.Exception;

namespace WebAPI.Services;

public class VoucherService
{
    private readonly UnitOfWork _unitOfWork;
    
    public VoucherService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Voucher>> GetAll()
    {
        return await _unitOfWork.Vouchers.GetAll();
    }

    public async Task<Voucher?> GetById(int id)
    {
        return await _unitOfWork.Vouchers.GetByIdWithRelations(id);
    }

    public async Task<Voucher> Create(VoucherInputDto voucherInputDto)
    {
        var voucher = new Voucher
        {
            Code = voucherInputDto.Code,
            Discount = voucherInputDto.Discount,
            ExpirationDate = voucherInputDto.ExpirationDate,
            Quantity = voucherInputDto.Quantity,
            Type = voucherInputDto.Type,
        };

        _unitOfWork.Vouchers.Add(voucher);

        await _unitOfWork.Complete();
        
        return voucher;
    } 
    
    public async Task<Voucher> Update(VoucherInputDto voucherInputDto, int voucherId)
    {
        var voucher = await _unitOfWork.Vouchers.GetById(voucherId);
        
        if (voucher == null)
        {
            throw new EntityNotFoundException<Voucher>(voucherId);
        }
        
        voucher.Code = voucherInputDto.Code;
        voucher.Discount = voucherInputDto.Discount;
        voucher.ExpirationDate = voucherInputDto.ExpirationDate;
        voucher.Quantity = voucherInputDto.Quantity;
        voucher.Type = voucherInputDto.Type;
        
        await _unitOfWork.Complete();

        return voucher;
    }
    
    public async Task Delete(int voucherId)
    {
        var voucher = await _unitOfWork.Vouchers.GetById(voucherId);

        if (voucher == null)
        {
            throw new EntityNotFoundException<Voucher>(voucherId);
        }

        _unitOfWork.Vouchers.Remove(voucher);

        await _unitOfWork.Complete();
    }
}