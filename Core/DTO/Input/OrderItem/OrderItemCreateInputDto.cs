namespace Core.DTO.Input.OrderItem;

public class OrderItemCreateInputDto
{
    public int Quantity { get; set; }
    public int Price { get; set; }
    public int BookId { get; set; }
    public int OrderId { get; set; }
}
