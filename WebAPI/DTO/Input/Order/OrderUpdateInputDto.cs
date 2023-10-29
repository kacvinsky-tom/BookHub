using DataAccessLayer.Enum;

namespace BookHub.DTO.Input.Order;

public class OrderUpdateInputDto
{
    public OrderStatus Status { get; set; }
}