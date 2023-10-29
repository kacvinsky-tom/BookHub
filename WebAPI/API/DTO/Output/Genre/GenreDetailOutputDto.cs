using BookHub.API.DTO.Output.Book;

namespace BookHub.API.DTO.Output;

public class GenreDetailOutputDto : OutputDtoBase
{
    public string Name { get; set; }
    public IEnumerable<BookListWithoutAuthorOutputDto> Books { get; set; }
}