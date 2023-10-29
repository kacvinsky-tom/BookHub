using WebAPI.DTO.Output.CartItem;
using WebAPI.DTO.Output.Order;
using WebAPI.DTO.Output.Review;
using WebAPI.DTO.Output.WishList;

namespace WebAPI.DTO.Output.User;

public class UserDetailOutputDto : OutputDtoBase
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsAdmin { get; set; }
    public IEnumerable<OrderListOutputDto> Orders { get; set; }
    public IEnumerable<CartItemListWithoutUserOutputDto> CartItems { get; set; }
    public IEnumerable<ReviewListOutputDto> Reviews { get; set; }
    public IEnumerable<WishListListWithoutUserOutputDto> WishLists { get; set; }
}