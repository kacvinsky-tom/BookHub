namespace BookHub.DTO.Input.Order;

public class OrderCreateInputDto
{
    public int UserId { get; set; }
    public int? VoucherUsedId { get; set; }
}