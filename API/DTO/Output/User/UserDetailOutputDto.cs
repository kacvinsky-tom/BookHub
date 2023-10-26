using BookHub.DataAccessLayer.Dtos;

namespace BookHub.API.DTO.Output;

public class UserDetailOutputDto : OutputDtoBase
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsAdmin { get; set; }
    public IEnumerable<OrderListOutputDto> Orders { get; set; }
    public IEnumerable<CartItemOutputDto> CartItems { get; set; }
    public IEnumerable<ReviewListOutputDto> Reviews { get; set; }
    public IEnumerable<WishListListOutputDto> WishLists { get; set; }
}