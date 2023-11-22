using DataAccessLayer.Enum;

namespace DataAccessLayer.Entity;

public class Order : BaseEntity
{
    public int TotalPrice { get; set; }

    public OrderStatus Status { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    public int? VoucherUsedId { get; set; }
    public virtual Voucher? VoucherUsed { get; set; }

    public IEnumerable<OrderItem> OrderItems { get; } = new List<OrderItem>();
}
