using BookHub.API.DTO.Output;
using BookHub.API.DTO.Output.Order;
using DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class OrderMapper
{
    public static OrderListOutputDto MapList(Order order)
    {
        return new OrderListOutputDto()
        {
            Id = order.Id,
            TotalPrice = order.TotalPrice,
            UserId = order.UserId,
            UserFirstName = order.User.FirstName,
            UserLastName = order.User.LastName,
        };
    }
    public static OrderDetailOutputDto MapDetail(Order order)
    {
        return new OrderDetailOutputDto()
        {
            Id = order.Id,
            TotalPrice = order.TotalPrice,
            Status = order.Status,
            User = UserMapper.MapDetail(order.User),
            OrderItems = order.OrderItems.Select(OrderItemMapper.MapList).ToList()
        };
    }
}