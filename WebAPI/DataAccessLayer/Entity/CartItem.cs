namespace BookHub.DataAccessLayer.Entity;

public class CartItem : BaseEntity
{
    public int BookId { get; set; }
    public virtual Book Book { get; set; } = null!;

    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
    
    public int Quantity { get; set; }
}