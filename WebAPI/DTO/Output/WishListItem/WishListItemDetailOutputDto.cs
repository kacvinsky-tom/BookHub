using WebAPI.DTO.Output.Author;
using WebAPI.DTO.Output.Genre;

namespace WebAPI.DTO.Output.WishListItem;

public class WishListItemDetailOutputDto : OutputDtoBase
{
    public string BookTitle { get; set; }
    public double BookPrice { get; set; }
    public int BookReleaseYear { get; set; }
    public string BookDescription { get; set; }
    public string BookISBN { get; set; }
    public string BookImage { get; set; }
    public IEnumerable<AuthorListOutputDto> BookAuthors { get; set; }
    public IEnumerable<GenreListOutputDto> Genres { get; set; }
}