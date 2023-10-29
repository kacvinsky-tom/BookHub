namespace BookHub.API.DTO.Input;

public class CartItemCreateInputDto
{
    public int BookId { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
}