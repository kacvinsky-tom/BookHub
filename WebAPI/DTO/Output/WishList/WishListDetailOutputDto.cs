using WebAPI.DTO.Output.WishListItem;

namespace WebAPI.DTO.Output.WishList;

public class WishListDetailOutputDto : OutputDtoBase
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public IEnumerable<WishListItemListOutputDto> WishListItems { get; set; }
}