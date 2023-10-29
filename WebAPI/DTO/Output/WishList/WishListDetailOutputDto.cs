
using BookHub.DTO.Output.WishListItem;

namespace BookHub.DTO.Output.WishList;

public class WishListDetailOutputDto : OutputDtoBase
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public IEnumerable<WishListItemListOutputDto> WishListItems { get; set; }
}