namespace BookHub.API.DTO.Input;

public class OrderCreateInputDto
{
    public int UserId { get; set; }
    public int? VoucherUsedId { get; set; }
}