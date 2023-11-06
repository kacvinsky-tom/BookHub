using WebAPI.DTO.Output.Author;

namespace WebAPI.DTO.Output.WishListItem;

public class WishListItemListOutputDto : OutputDtoBase
{
    public string BookTitle { get; set; }
    public double BookPrice { get; set; }
    public int BookReleaseYear { get; set; }
    public string BookImage { get; set; }
    public IEnumerable<AuthorListOutputDto> BookAuthors { get; set; }
}