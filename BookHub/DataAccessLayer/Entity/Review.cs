namespace BookHub.DataAccessLayer.Entity;

public class Review : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public int BookId { get; set; }
    public virtual Book Book { get; set; } = null!;
    
    public string Comment { get; set; }
    
    public int Rating { get; set; }
}