using DataAccessLayer.Enum;

namespace Core.DTO.Input.Order;

public class OrderUpdateInputDto
{
    public OrderStatus Status { get; set; }
}