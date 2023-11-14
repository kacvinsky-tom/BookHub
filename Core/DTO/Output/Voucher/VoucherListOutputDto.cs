using DataAccessLayer.Enum;

namespace Core.DTO.Output.Voucher;

public class VoucherListOutputDto : OutputDtoBase
{
    public string Code { get; set; }
    public int Discount { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Quantity { get; set; }
    public int UsedQuantity { get; set; }
    public VoucherType Type { get; set; }
    public bool IsUsable { get; set; }
}