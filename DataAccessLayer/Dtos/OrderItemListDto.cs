namespace BookHub.DataAccessLayer.Dtos;

public class OrderItemListDto : DtoBase
{
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string ISBN { get; set; }
    public string Title { get; set; }
}