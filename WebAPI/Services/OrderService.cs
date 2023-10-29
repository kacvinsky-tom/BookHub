﻿using System.ComponentModel;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Enum;
using DataAccessLayer.Exception;
using WebAPI.DTO.Input.Order;
using WebAPI.DTO.Input.OrderItem;

namespace WebAPI.Services;

public class OrderService
{
    private readonly UnitOfWork _unitOfWork;
    
    public OrderService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Order> Create(OrderCreateInputDto orderCreateInputDto)
    {
        var user = await _unitOfWork.Users.GetById(orderCreateInputDto.UserId);

        if (user == null)
        {
            throw new EntityNotFoundException<User>(orderCreateInputDto.UserId);
        }

        var voucher = await _unitOfWork.Vouchers.GetById(orderCreateInputDto.VoucherUsedId.GetValueOrDefault());

        if (voucher != null)
        {
            return new Order
            {
                UserId = orderCreateInputDto.UserId,
                User = user,
                VoucherUsed = voucher,
                VoucherUsedId = voucher.Id
            };
        }
        
        return new Order
        {
            UserId = orderCreateInputDto.UserId,
            User = user,
        };
    }

    public void Update(OrderUpdateInputDto orderUpdateInputDto, Order order)
    {
        var status = orderUpdateInputDto.Status;

        if (!Enum.IsDefined(typeof(OrderStatus), status))
        {
            throw new InvalidEnumArgumentException("Invalid order status.");
        }

        order.Status = status;
    }
    
    public async Task<OrderItem> CreateItemInWishlist(OrderItemCreateInputDto orderItemInputDto)
    {
        var order = await _unitOfWork.Orders.GetById(orderItemInputDto.OrderId);

        if (order == null)
        {
            throw new EntityNotFoundException<Order>(orderItemInputDto.OrderId);
        }

        var book = await _unitOfWork.Books.GetById(orderItemInputDto.BookId);

        if (book == null)
        {
            throw new EntityNotFoundException<Book>(orderItemInputDto.BookId);
        }

        order.TotalPrice += orderItemInputDto.Price;
        
        var orderItem = new OrderItem
        {
            Order = order,
            OrderId = order.Id,
            Book = book,
            BookId = book.Id,
            ISBN = book.ISBN,
            Title = book.Title,
            Price = orderItemInputDto.Price,
            Quantity = orderItemInputDto.Quantity
        };

        return orderItem;
    }
}