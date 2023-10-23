namespace BookHub.DataAccessLayer.Dtos;

public class WishListDetailDto : DtoBase
{
    public string Name { get; set; }
    public ICollection<WishListItemDto> WishListItems { get; set; }
}