namespace DataAccessLayer.Entity;

public class Book : BaseEntity
{
    public string Title { get; set; } = "";

    public string ISBN { get; set; } = "";

    public string Description { get; set; } = "";

    public string? Image { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public int ReleaseYear { get; set; }

    public bool IsDeleted { get; set; }
    public int PublisherId { get; set; }
    public virtual Publisher Publisher { get; set; } = null!;
    public IEnumerable<Author> Authors { get; set; } = new List<Author>();
    public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();

    public IEnumerable<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public IEnumerable<CartItem> CartItems { get; } = new List<CartItem>();
    public IEnumerable<Review> Reviews { get; } = new List<Review>();

    public IEnumerable<WishListItem> WishListItems { get; } = new List<WishListItem>();
}
