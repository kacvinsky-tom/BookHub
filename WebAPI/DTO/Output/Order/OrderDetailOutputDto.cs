using DataAccessLayer.Enum;
using WebAPI.DTO.Output.OrderItem;
using WebAPI.DTO.Output.User;

namespace WebAPI.DTO.Output.Order;

public class OrderDetailOutputDto : OutputDtoBase
{
    public int TotalPrice { get; set; }
    public OrderStatus Status { get; set; }
    public UserDetailOutputDto User { get; set; }
    public ICollection<OrderItemListOutputDto> OrderItems { get; set; }
}