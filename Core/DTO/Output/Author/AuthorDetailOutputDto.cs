using Core.DTO.Output.Book;

namespace Core.DTO.Output.Author;

public class AuthorDetailOutputDto : OutputDtoBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IEnumerable<BookListWithoutAuthorOutputDto> Books { get; set; }
}
