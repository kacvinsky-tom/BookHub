using Core.DTO.Output.Book;

namespace Core.DTO.Output.Genre;

public class GenreDetailOutputDto : OutputDtoBase
{
    public string Name { get; set; }
    public IEnumerable<BookListWithoutAuthorOutputDto> Books { get; set; }
}
