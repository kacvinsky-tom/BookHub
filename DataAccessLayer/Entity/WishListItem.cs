namespace DataAccessLayer.Entity;

public class WishListItem : BaseEntity
{
    public int WishListId { get; set; }
    public virtual WishList WishList { get; set; } = null!;

    public int BookId { get; set; }
    public virtual Book Book { get; set; } = null!;
}