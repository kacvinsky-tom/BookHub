namespace BookHub.DataAccessLayer.Entity;

public class WishList : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public string Name { get; set; }

    public ICollection<WishListItem> WishListItems { get; } = new List<WishListItem>();
}