using WebAPI.DTO.Output.Book;

namespace WebAPI.DTO.Output.Author;

public class AuthorDetailOutputDto : OutputDtoBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IEnumerable<BookListWithoutAuthorOutputDto> Books { get; set; }
}