using BookHub.API.DTO.Output.OrderItem;

namespace BookHub.API.DTO.Output.Order;

public class OrderListOutputDto : OutputDtoBase
{
    public int TotalPrice { get; set; }
    public string UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public ICollection<OrderItemListOutputDto> OrderItems { get; set; }
}