namespace BookHub.DataAccessLayer.Dtos;

public class UserDetailDto : DtoBase
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsAdmin { get; set; }
    public IEnumerable<OrderListDto> Orders { get; set; }
    public IEnumerable<CartItemDto> CartItems { get; set; }
    public IEnumerable<ReviewListDto> Reviews { get; set; }
    public IEnumerable<WishListListDto> WishLists { get; set; }
}