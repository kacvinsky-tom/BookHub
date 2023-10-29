using BookHub.DTO.Output.Book;
using BookHub.DTO.Output.User;

namespace BookHub.DTO.Output.CartItem;

public class CartItemDetailOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    public UserListOutputDto User { get; set; }
    public BookListOutputDto Book { get; set; }
}