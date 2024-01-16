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

    public IList<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    public IList<Author> Authors { get; set; } = new List<Author>();
    public IList<Genre> Genres { get; set; } = new List<Genre>();

    public IList<BookGenre> BookGenres { get; set; } = new List<BookGenre>();

    public IList<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public IList<CartItem> CartItems { get; } = new List<CartItem>();
    public IList<Review> Reviews { get; } = new List<Review>();

    public IList<WishListItem> WishListItems { get; } = new List<WishListItem>();
}
