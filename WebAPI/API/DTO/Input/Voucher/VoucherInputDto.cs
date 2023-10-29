using DataAccessLayer.Enum;

namespace BookHub.API.DTO.Input;

public class VoucherInputDto
{
    public string Code { get; set; }
    public int Discount { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Quantity { get; set; }
    public VoucherType Type { get; set; }
}