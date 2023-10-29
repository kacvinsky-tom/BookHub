﻿using BookHub.API.DTO.Output;
using BookHub.API.DTO.Output.Order;
using BookHub.API.DTO.Output.OrderItem;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class OrderItemMapper
{
    public static OrderItemListOutputDto MapList(OrderItem orderItem)
    {
        return new OrderItemListOutputDto()
        {
            Id = orderItem.Id,
            Quantity = orderItem.Quantity,
            Price = orderItem.Price,
            ISBN = orderItem.ISBN,
            Title = orderItem.Title
        };
    }
    public static OrderItemDetailOutputDto MapDetail(OrderItem orderItem)
    {
        return new OrderItemDetailOutputDto()
        {
            Id = orderItem.Id,
            Quantity = orderItem.Quantity,
            Price = orderItem.Price,
            BookTitle = orderItem.Book.Title,
            BookId = orderItem.Book.Id,
            Order = OrderMapper.MapList(orderItem.Order)
        };
    }
    public static OrderItemCreateOutputDto MapCreateDetail(OrderItem orderItem)
    {
        return new OrderItemCreateOutputDto()
        {
            Id = orderItem.Id,
            Quantity = orderItem.Quantity,
            Price = orderItem.Price,
            BookTitle = orderItem.Book.Title,
            BookId = orderItem.Book.Id,
            OrderId = orderItem.OrderId,
            OrderPrice = orderItem.Order.TotalPrice
        };
    }
}