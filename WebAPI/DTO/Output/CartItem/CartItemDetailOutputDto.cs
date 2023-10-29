using WebAPI.DTO.Output.Book;
using WebAPI.DTO.Output.User;

namespace WebAPI.DTO.Output.CartItem;

public class CartItemDetailOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    public UserListOutputDto User { get; set; }
    public BookListOutputDto Book { get; set; }
}