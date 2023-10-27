
namespace BookHub.DataAccessLayer.Entity;

public class Book : BaseEntity
{
    public string Title { get; set; }

    public string ISBN { get; set; }

    public string Description { get; set; }

    public string? Image { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public int ReleaseYear { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public int PublisherId { get; set; }
    public virtual Publisher Publisher { get; set; } = null!;
    
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; } = null!;
    
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    
    public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
    
    public ICollection<CartItem> CartItems { get; } = new List<CartItem>();
    
    public ICollection<Review> Reviews { get; } = new List<Review>();
    
    public ICollection<WishListItem> WishListItems { get; } = new List<WishListItem>();
}