namespace Core.DTO.Output.CartItem;

public class CartItemListOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string BookTitle { get; set; }
    public int BookId { get; set; }
}
