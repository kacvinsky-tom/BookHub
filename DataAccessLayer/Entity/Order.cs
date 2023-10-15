using BookHub.Enum;

namespace BookHub.DataAccessLayer.Entity;

public class Order : BaseEntity
{
    public int TotalPrice { get; set; }

    public OrderStatus Status { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
    
    public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
}