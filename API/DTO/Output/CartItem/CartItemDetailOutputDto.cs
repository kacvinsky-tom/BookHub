using BookHub.API.DTO.Output.Book;
using BookHub.API.DTO.Output.User;

namespace BookHub.API.DTO.Output.CartItem;

public class CartItemDetailOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    public UserListOutputDto User { get; set; }
    public BookListOutputDto Book { get; set; }
}