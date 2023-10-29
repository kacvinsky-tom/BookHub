using DataAccessLayer.Enum;

namespace DataAccessLayer.Entity;

public class Voucher : BaseEntity
{
    public string Code { get; set; } = null!;
    public int Discount { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Quantity { get; set; }
    public VoucherType Type { get; set; }
    public IEnumerable<Order> Orders { get; set; } = null!;

    public int UsedQuantity => Orders?.Count() ?? 0;
    public bool IsUsable => (Quantity == 0 || UsedQuantity < Quantity) && ExpirationDate > DateTime.Now;

    
}