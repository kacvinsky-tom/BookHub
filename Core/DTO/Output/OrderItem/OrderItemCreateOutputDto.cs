namespace Core.DTO.Output.OrderItem;

public class OrderItemCreateOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    public int Price { get; set; }
    public string BookTitle { get; set; } = "";
    public int BookId { get; set; }
    public int OrderId { get; set; }
    public int OrderPrice { get; set; }
}
