using Core.DTO.Output.Author;
using Core.DTO.Output.Genre;

namespace Core.DTO.Output.Book;

public class BookListOutputDto : OutputDtoBase
{
    public string Title { get; set; } = "";
    public int Price { get; set; }
    public int ReleaseYear { get; set; }
    public string PublisherName { get; set; } = "";

    public IEnumerable<AuthorListOutputDto> Authors { get; set; } = new List<AuthorListOutputDto>();
    public IEnumerable<BookGenreListOutputDto> Genres { get; set; } =
        new List<BookGenreListOutputDto>();
}
