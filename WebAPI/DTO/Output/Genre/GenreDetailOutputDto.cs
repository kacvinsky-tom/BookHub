using WebAPI.DTO.Output.Book;

namespace WebAPI.DTO.Output.Genre;

public class GenreDetailOutputDto : OutputDtoBase
{
    public string Name { get; set; }
    public IEnumerable<BookListWithoutAuthorOutputDto> Books { get; set; }
}