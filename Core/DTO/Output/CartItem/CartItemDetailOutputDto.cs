using Core.DTO.Output.Book;
using Core.DTO.Output.User;

namespace Core.DTO.Output.CartItem;

public class CartItemDetailOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    public UserListOutputDto User { get; set; } = new();
    public BookListOutputDto Book { get; set; } = new();
}
