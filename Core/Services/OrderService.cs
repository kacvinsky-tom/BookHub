using System.ComponentModel;
using Core.DTO.Input.Order;
using Core.DTO.Input.OrderItem;
using Core.Exception;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Enum;
using DataAccessLayer.Helpers;

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

    public async Task<IEnumerable<Order>> GetAllByUserId(int id)
    {
        return await _unitOfWork.Orders.GetAllByUserId(id);
    }

    public async Task<IEnumerable<OrderItem>> GetAllOrderItems()
    {
        return await _unitOfWork.OrderItems.GetAllWithRelations();
    }

    public async Task<PaginationObject<Order>> GetAllPaginated(int page, int pageSize)
    {
        return await _unitOfWork.Orders.GetPaginated(page, pageSize);
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

        var voucher = await _unitOfWork.Vouchers.GetById(
            orderCreateInputDto.VoucherUsedId.GetValueOrDefault()
        );

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
            Price = orderItemInputDto.Quantity * book.Price,
            Quantity = orderItemInputDto.Quantity
        };

        await _unitOfWork.OrderItems.Add(orderItem);
        await _unitOfWork.Complete();

        return orderItem;
    }

    public async Task<OrderItem> UpdateOrderItem(
        OrderItemUpdateInputDto orderItemUpdateInputDto,
        int orderItemId
    )
    {
        var orderItem = await _unitOfWork.OrderItems.GetById(orderItemId);

        if (orderItem == null)
        {
            throw new EntityNotFoundException<OrderItem>(orderItemId);
        }

        var order = await _unitOfWork.Orders.GetById(orderItem.OrderId);

        if (order == null)
        {
            throw new EntityNotFoundException<Order>(orderItem.OrderId);
        }

        var book = await _unitOfWork.Books.GetById(orderItemUpdateInputDto.BookId);

        if (book == null)
        {
            throw new EntityNotFoundException<Book>(orderItemUpdateInputDto.BookId);
        }

        order.TotalPrice -= orderItem.Price;

        orderItem.Book = book;
        orderItem.BookId = book.Id;
        orderItem.ISBN = book.ISBN;
        orderItem.Title = book.Title;
        orderItem.Price = orderItemUpdateInputDto.Quantity * book.Price;
        orderItem.Quantity = orderItemUpdateInputDto.Quantity;

        order.TotalPrice += orderItem.Price;

        await _unitOfWork.Complete();

        return orderItem;
    }

    public async Task DeleteOrderItem(int orderItemId)
    {
        var orderItem = await _unitOfWork.OrderItems.GetById(orderItemId);

        if (orderItem == null)
        {
            throw new EntityNotFoundException<OrderItem>(orderItemId);
        }

        var order = await _unitOfWork.Orders.GetById(orderItem.OrderId);

        if (order == null)
        {
            throw new EntityNotFoundException<Order>(orderItem.OrderId);
        }

        order.TotalPrice -= orderItem.Price;

        _unitOfWork.OrderItems.Remove(orderItem);

        await _unitOfWork.Complete();
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
