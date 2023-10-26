namespace BookHub.API.DTO.Output.WishListItem;

public class WishListItemDetailOutputDto : OutputDtoBase
{
    public string BookTitle { get; set; }
    public double BookPrice { get; set; }
    public int BookReleaseYear { get; set; }
    public string BookDescription { get; set; }
    public string BookISBN { get; set; }
    public string BookImage { get; set; }
    

    // TODO uncomment after AuthorDto and GenreDto are implemented
    // public IEnumerable<AuthorDto> Authors { get; set; }
    // public IEnumerable<GenreDto> Genres { get; set; }
}