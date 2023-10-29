using BookHub.API.DTO.Output.Book;
using BookHub.API.DTO.Output.Order;

namespace BookHub.API.DTO.Output.OrderItem;

public class OrderItemDetailOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    public int Price { get; set; }
    public string BookTitle { get; set; }
    public int BookId { get; set; }
    public OrderListOutputDto Order { get; set; }
}