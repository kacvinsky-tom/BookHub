using BookHub.DTO.Output.CartItem;
using BookHub.DTO.Output.Order;
using BookHub.DTO.Output.Review;
using BookHub.DTO.Output.WishList;

namespace BookHub.DTO.Output.User;

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