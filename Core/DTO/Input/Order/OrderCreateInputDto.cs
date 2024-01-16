using DataAccessLayer.Enum;

namespace Core.DTO.Input.Order;

public class OrderCreateInputDto
{
    public int UserId { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public int? VoucherUsedId { get; set; }
}
