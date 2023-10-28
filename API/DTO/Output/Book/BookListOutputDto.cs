namespace BookHub.API.DTO.Output.Book;

public class BookListOutputDto : OutputDtoBase
{
    public string Title { get; set; }
    public int Price { get; set; }
    public int ReleaseYear { get; set; }
    
    public IEnumerable<AuthorListOutputDto> Authors { get; set; }
    // TODO Fill in GenreDto collections after they are implemented
}