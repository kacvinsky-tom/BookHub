using BookHub.DataAccessLayer.Entity;
using BookHub.Enum;

namespace BookHub.API.DTO.Input;

public class OrderUpdateInputDto
{
    public OrderStatus Status { get; set; }
}