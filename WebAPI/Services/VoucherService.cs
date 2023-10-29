using BookHub.DTO.Input.Voucher;
using DataAccessLayer.Entity;

namespace BookHub.Services;

public class VoucherService
{
    public Voucher Create(VoucherInputDto voucherInputDto)
    {
        return new Voucher
        {
            Code = voucherInputDto.Code,
            Discount = voucherInputDto.Discount,
            ExpirationDate = voucherInputDto.ExpirationDate,
            Quantity = voucherInputDto.Quantity,
            Type = voucherInputDto.Type,
        };
    } 
    
    public void Update(Voucher voucher, VoucherInputDto voucherInputDto)
    {
        voucher.Code = voucherInputDto.Code;
        voucher.Discount = voucherInputDto.Discount;
        voucher.ExpirationDate = voucherInputDto.ExpirationDate;
        voucher.Quantity = voucherInputDto.Quantity;
        voucher.Type = voucherInputDto.Type;
    }
}