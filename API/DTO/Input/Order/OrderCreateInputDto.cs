using BookHub.DataAccessLayer.Entity;
using BookHub.Enum;

namespace BookHub.API.DTO.Input;

public class OrderCreateInputDto
{
    public int UserId { get; set; }
    public int? VoucherUsedId { get; set; }
}