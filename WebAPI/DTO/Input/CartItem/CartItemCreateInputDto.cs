namespace BookHub.DTO.Input.CartItem;

public class CartItemCreateInputDto
{
    public int BookId { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
}