using BookHub.DTO.Output.Book;

namespace BookHub.DTO.Output.Author;

public class AuthorDetailOutputDto : OutputDtoBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IEnumerable<BookListWithoutAuthorOutputDto> Books { get; set; }
}