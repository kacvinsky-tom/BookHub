using Core.DTO.Output.Order;

namespace Core.DTO.Output.OrderItem;

public class OrderItemDetailOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    public int Price { get; set; }
    public string BookTitle { get; set; }
    public int BookId { get; set; }
    public OrderListOutputDto Order { get; set; }
}