using BookHub.API.DTO.Output.CartItem;
using BookHub.API.DTO.Output.Order;
using BookHub.API.DTO.Output.Review;
using BookHub.API.DTO.Output.WishList;

namespace BookHub.API.DTO.Output.User;

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