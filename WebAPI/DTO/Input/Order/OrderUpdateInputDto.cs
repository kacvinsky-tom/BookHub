using DataAccessLayer.Enum;

namespace WebAPI.DTO.Input.Order;

public class OrderUpdateInputDto
{
    public OrderStatus Status { get; set; }
}