using Core.DTO.Output.Author;
using Core.DTO.Output.Genre;

namespace Core.DTO.Output.Book;

public class BookListOutputDto : OutputDtoBase
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public int Price { get; set; }
    public int ReleaseYear { get; set; }
    public string? Image { get; set; } = null;
    public string PublisherName { get; set; } = "";

    public IEnumerable<AuthorListOutputDto> Authors { get; set; } = new List<AuthorListOutputDto>();
    public IEnumerable<BookGenreListOutputDto> BookGenres { get; set; } =
        new List<BookGenreListOutputDto>();
}
