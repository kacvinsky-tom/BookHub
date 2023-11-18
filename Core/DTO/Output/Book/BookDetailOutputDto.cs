using Core.DTO.Output.Author;
using Core.DTO.Output.Genre;
using Core.DTO.Output.Publisher;
using Core.DTO.Output.Review;

namespace Core.DTO.Output.Book;

public class BookDetailOutputDto : OutputDtoBase
{
    public string Title { get; set; } = "";

    public string ISBN { get; set; } = "";

    public string Description { get; set; } = "";

    public string? Image { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public PublisherDetailOutputDto Publisher { get; set; } = new();

    public int ReleaseYear { get; set; }

    public IEnumerable<AuthorListOutputDto> Authors { get; set; } = new List<AuthorListOutputDto>();

    public IEnumerable<GenreListOutputDto> Genres { get; set; } = new List<GenreListOutputDto>();

    public IEnumerable<ReviewListOutputDto> Reviews { get; set; } = new List<ReviewListOutputDto>();
}
