namespace BookHub.API.DTO.Output;

public class AuthorDetailOutputDto : OutputDtoBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IEnumerable<BookListWithoutAuthorOutputDto> Books { get; set; }
}