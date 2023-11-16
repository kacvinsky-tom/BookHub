namespace DataAccessLayer.Entity;

public class OrderItem : BaseEntity
{
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;
    public int? BookId { get; set; }
    public virtual Book Book { get; set; } = null!;
    public int Quantity { get; set; }

    public int Price { get; set; }

    public string Title { get; set; }

    public string ISBN { get; set; }
}
