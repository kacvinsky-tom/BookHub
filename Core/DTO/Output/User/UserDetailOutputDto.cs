using Core.DTO.Output.CartItem;
using Core.DTO.Output.Order;
using Core.DTO.Output.Review;
using Core.DTO.Output.WishList;

namespace Core.DTO.Output.User;

public class UserDetailOutputDto : OutputDtoBase
{
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public bool IsAdmin { get; set; }
    public IEnumerable<OrderListOutputDto> Orders { get; set; } = new List<OrderListOutputDto>();

    public IEnumerable<CartItemListWithoutUserOutputDto> CartItems { get; set; } =
        new List<CartItemListWithoutUserOutputDto>();

    public IEnumerable<ReviewListOutputDto> Reviews { get; set; } = new List<ReviewListOutputDto>();

    public IEnumerable<WishListListWithoutUserOutputDto> WishLists { get; set; } =
        new List<WishListListWithoutUserOutputDto>();
}
