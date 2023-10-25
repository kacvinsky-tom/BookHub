namespace BookHub.API.DTO.Output;

public class WishListItemListOutputDto : OutputDtoBase
{
    public string BookTitle { get; set; }
    public double BookPrice { get; set; }
    public int BookReleaseYear { get; set; }
    public string BookImage { get; set; }
    
    // TODO Uncomment this after AuthorDto is implemented
    // public IEnumerable<AuthorDto> Authors { get; set; }

    
}