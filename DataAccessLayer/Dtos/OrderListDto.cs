namespace BookHub.DataAccessLayer.Dtos;

public class OrderListDto : DtoBase
{
    public int TotalPrice { get; set; }
    public string UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public ICollection<OrderItemListDto> OrderItems { get; set; }
}