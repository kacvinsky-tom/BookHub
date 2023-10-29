using BookHub.DTO.Output.OrderItem;
using BookHub.DTO.Output.User;
using DataAccessLayer.Enum;

namespace BookHub.DTO.Output.Order;

public class OrderDetailOutputDto : OutputDtoBase
{
    public int TotalPrice { get; set; }
    public OrderStatus Status { get; set; }
    public UserDetailOutputDto User { get; set; }
    public ICollection<OrderItemListOutputDto> OrderItems { get; set; }
}