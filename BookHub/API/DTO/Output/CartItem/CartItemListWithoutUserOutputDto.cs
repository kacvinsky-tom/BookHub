using BookHub.API.DTO.Output.Book;
using BookHub.API.DTO.Output.User;

namespace BookHub.API.DTO.Output.CartItem;

public class CartItemListWithoutUserOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    public string BookTitle { get; set; }
    public int BookId { get; set; }
}