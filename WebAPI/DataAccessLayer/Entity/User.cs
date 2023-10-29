namespace BookHub.DataAccessLayer.Entity;

public class User : BaseEntity 
{
    public string Username { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }

    public bool IsAdmin { get; set; }

    public ICollection<Order> Orders { get; } = new List<Order>();

    public ICollection<CartItem> CartItems { get; } = new List<CartItem>();
    
    public ICollection<Review> Reviews { get; } = new List<Review>();
    
    public ICollection<WishList> WishLists { get; } = new List<WishList>();
}