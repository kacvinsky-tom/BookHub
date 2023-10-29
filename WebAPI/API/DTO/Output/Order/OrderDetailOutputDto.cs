using BookHub.API.DTO.Output.OrderItem;
using BookHub.API.DTO.Output.User;
using BookHub.Services;
using DataAccessLayer.Enum;

namespace BookHub.API.DTO.Output.Order;

public class OrderDetailOutputDto : OutputDtoBase
{
    public int TotalPrice { get; set; }
    public OrderStatus Status { get; set; }
    public UserDetailOutputDto User { get; set; }
    public ICollection<OrderItemListOutputDto> OrderItems { get; set; }
}