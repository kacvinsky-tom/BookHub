namespace Core.DTO.Output.OrderItem;

public class OrderItemListOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    public int Price { get; set; }
    public string ISBN { get; set; }
    public string Title { get; set; }
}