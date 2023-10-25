
namespace BookHub.API.DTO.Output;

public class WishListDetailOutputDto : OutputDtoBase
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public IEnumerable<WishListItemListOutputDto> WishListItems { get; set; }
}