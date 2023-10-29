using DataAccessLayer.Entity;
using WebAPI.DTO.Output.Voucher;

namespace WebAPI.Mapper;

public static class VoucherMapper
{
    public static VoucherListOutputDto MapList(Voucher voucher)
    {
        return new VoucherListOutputDto
        {
            Id = voucher.Id,
            Code = voucher.Code,
            Discount = voucher.Discount,
            ExpirationDate = voucher.ExpirationDate,
            Quantity = voucher.Quantity,
            UsedQuantity = voucher.UsedQuantity,
            Type = voucher.Type,
            IsUsable = voucher.IsUsable
        };
    }

    public static VoucherDetailOutputDto MapDetail(Voucher voucher)
    {
        return new VoucherDetailOutputDto
        {
            Id = voucher.Id,
            Code = voucher.Code,
            Discount = voucher.Discount,
            ExpirationDate = voucher.ExpirationDate,
            Quantity = voucher.Quantity,
            UsedQuantity = voucher.UsedQuantity,
            Type = voucher.Type,
            Orders = voucher.Orders.Select(OrderMapper.MapList)
        };
    }
}