using BookHub.API.DTO.Output.Order;
using BookHub.DataAccessLayer.Enum;

namespace BookHub.API.DTO.Output;

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