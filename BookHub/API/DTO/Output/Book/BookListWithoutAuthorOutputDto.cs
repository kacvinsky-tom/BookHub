namespace BookHub.API.DTO.Output;

public class BookListWithoutAuthorOutputDto : OutputDtoBase
{
    public string Title { get; set; }
    public int Price { get; set; }
    public int ReleaseYear { get; set; }
}