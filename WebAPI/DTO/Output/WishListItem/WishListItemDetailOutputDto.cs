using BookHub.DTO.Output.Author;
using BookHub.DTO.Output.Genre;

namespace BookHub.DTO.Output.WishListItem;

public class WishListItemDetailOutputDto : OutputDtoBase
{
    public string BookTitle { get; set; }
    public double BookPrice { get; set; }
    public int BookReleaseYear { get; set; }
    public string BookDescription { get; set; }
    public string BookISBN { get; set; }
    public string BookImage { get; set; }

    public IEnumerable<AuthorListOutputDto> Authors { get; set; }
    
    public IEnumerable<GenreListOutputDto> Genres { get; set; }
}