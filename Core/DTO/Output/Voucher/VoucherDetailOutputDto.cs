using Core.DTO.Output.Order;
using DataAccessLayer.Enum;

namespace Core.DTO.Output.Voucher;

public class VoucherDetailOutputDto : OutputDtoBase
{
    public string Code { get; set; }
    public int Discount { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Quantity { get; set; }
    public int UsedQuantity { get; set; }
    public VoucherType Type { get; set; }
    public IEnumerable<OrderListOutputDto> Orders { get; set; } = null!;
}
