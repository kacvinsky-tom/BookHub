using System.ComponentModel;
using Core.DTO.Input.Order;
using Core.DTO.Input.OrderItem;
using Core.Exception;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Enum;

namespace Core.Services;

public class OrderService
{
    private readonly UnitOfWork _unitOfWork;

    public OrderService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        return await _unitOfWork.Orders.GetAllWithRelations();
    }

    public async Task<IEnumerable<OrderItem>> GetAllOrderItems()
    {
        return await _unitOfWork.OrderItems.GetAllWithRelations();
    }

    public async Task<Order?> GetById(int id)
    {
        return await _unitOfWork.Orders.GetByIdWithRelations(id);
    }

    public async Task<OrderItem?> GetOrderItemById(int id)
    {
        return await _unitOfWork.OrderItems.GetByIdWithRelations(id);
    }

    public async Task<Order> Create(OrderCreateInputDto orderCreateInputDto)
    {
        var user = await _unitOfWork.Users.GetById(orderCreateInputDto.UserId);

        if (user == null)
        {
            throw new EntityNotFoundException<User>(orderCreateInputDto.UserId);
        }

        var voucher = await _unitOfWork
            .Vouchers
            .GetById(orderCreateInputDto.VoucherUsedId.GetValueOrDefault());

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

        var order = new Order { UserId = orderCreateInputDto.UserId, User = user, };

        await _unitOfWork.Orders.Add(order);

        await _unitOfWork.Complete();

        return order;
    }

    public async Task<Order> Update(OrderUpdateInputDto orderUpdateInputDto, int orderId)
    {
        var order = await _unitOfWork.Orders.GetByIdWithRelations(orderId);

        if (order == null)
        {
            throw new EntityNotFoundException<Order>(orderId);
        }

        var status = orderUpdateInputDto.Status;

        if (!Enum.IsDefined(typeof(OrderStatus), status))
        {
            throw new InvalidEnumArgumentException("Invalid order status.");
        }

        order.Status = status;

        await _unitOfWork.Complete();

        return order;
    }

    public async Task<OrderItem> CreateOrderItem(OrderItemCreateInputDto orderItemInputDto)
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

        await _unitOfWork.OrderItems.Add(orderItem);
        await _unitOfWork.Complete();

        return orderItem;
    }

    public async Task Delete(int orderId)
    {
        var order = await _unitOfWork.Orders.GetById(orderId);

        if (order == null)
        {
            throw new EntityNotFoundException<Order>(orderId);
        }

        _unitOfWork.Orders.Remove(order);

        await _unitOfWork.Complete();
    }
}
