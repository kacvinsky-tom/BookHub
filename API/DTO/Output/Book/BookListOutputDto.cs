namespace BookHub.API.DTO.Output;

public class BookListOutputDto : OutputDtoBase
{
    public string Title { get; set; }
    public double Price { get; set; }
    public int ReleaseYear { get; set; }
    // TODO Fill in AuthorDto and GenreDto collections after they are implemented
}