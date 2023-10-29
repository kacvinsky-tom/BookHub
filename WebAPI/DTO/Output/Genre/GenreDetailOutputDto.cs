using BookHub.DTO.Output.Book;

namespace BookHub.DTO.Output.Genre;

public class GenreDetailOutputDto : OutputDtoBase
{
    public string Name { get; set; }
    public IEnumerable<BookListWithoutAuthorOutputDto> Books { get; set; }
}