namespace BookHub.DataAccessLayer.Dtos;

public class WishListDetailDto : DtoBase
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public IEnumerable<WishListItemListDto> WishListItems { get; set; }
}