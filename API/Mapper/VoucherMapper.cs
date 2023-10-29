﻿using BookHub.API.DTO.Output;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

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
        return new VoucherDetailOutputDto()
        {
            Id = voucher.Id,
            Code = voucher.Code,
            Discount = voucher.Discount,
            ExpirationDate = voucher.ExpirationDate,
            Quantity = voucher.Quantity,
            UsedQuantity = voucher.UsedQuantity,
            Type = voucher.Type,
            // TODO uncomment after OrderMapper is fully implemented
            //Orders = voucher.Orders.Select(OrderMapper.MapList)
        };
    }
}