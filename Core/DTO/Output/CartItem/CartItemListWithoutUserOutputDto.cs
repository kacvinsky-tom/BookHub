namespace Core.DTO.Output.CartItem;

public class CartItemListWithoutUserOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    public string BookTitle { get; set; }
    public int BookId { get; set; }
}
