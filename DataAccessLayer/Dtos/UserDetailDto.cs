namespace BookHub.DataAccessLayer.Dtos;

public class UserDetailDto : DtoBase
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsAdmin { get; set; }
    public ICollection<OrderListDto> Orders { get; set; }
    public ICollection<CartItemDto> CartItems { get; set; }
    public ICollection<ReviewListDto> Reviews { get; set; }
    public ICollection<WishListListDto> WishLists { get; set; }
}