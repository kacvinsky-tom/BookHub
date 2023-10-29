using DataAccessLayer.Enum;
using WebAPI.DTO.Output.Order;

namespace WebAPI.DTO.Output.Voucher;

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