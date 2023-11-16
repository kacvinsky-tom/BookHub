namespace DataAccessLayer.Entity;

public class User : BaseEntity
{
    public string Username { get; set; } = "";

    public string Email { get; set; } = "";

    public string Password { get; set; } = "";

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public bool IsAdmin { get; set; }

    public IEnumerable<Order> Orders { get; } = new List<Order>();

    public IEnumerable<CartItem> CartItems { get; } = new List<CartItem>();

    public IEnumerable<Review> Reviews { get; } = new List<Review>();

    public IEnumerable<WishList> WishLists { get; } = new List<WishList>();
}
