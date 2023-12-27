using Core.DTO.Output.Author;
using Core.DTO.Output.Genre;

namespace Core.DTO.Output.WishListItem;

public class WishListItemDetailOutputDto : OutputDtoBase
{
    public string BookTitle { get; set; } = "";
    public double BookPrice { get; set; }
    public int BookReleaseYear { get; set; }
    public string BookDescription { get; set; } = "";
    public string BookISBN { get; set; } = "";
    public string BookImage { get; set; } = "";
    public IEnumerable<AuthorListOutputDto> BookAuthors { get; set; } =
        new List<AuthorListOutputDto>();
    public IEnumerable<BookGenreListOutputDto> BookBookGenres { get; set; } =
        new List<BookGenreListOutputDto>();
}
