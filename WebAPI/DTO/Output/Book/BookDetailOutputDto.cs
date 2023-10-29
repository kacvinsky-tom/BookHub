using BookHub.DTO.Output.Author;
using BookHub.DTO.Output.Genre;
using BookHub.DTO.Output.Publisher;
using BookHub.DTO.Output.Review;

namespace BookHub.DTO.Output.Book;

public class BookDetailOutputDto : OutputDtoBase
{
    public string Title { get; set; }

    public string ISBN { get; set; }

    public string Description { get; set; }

    public string? Image { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public PublisherDetailOutputDto Publisher { get; set; }

    public int ReleaseYear { get; set; }
    
    public IEnumerable<AuthorListOutputDto> Authors { get; set; }
    
    public ICollection<GenreListOutputDto> Genres { get; set; }
    
    public IEnumerable<ReviewListOutputDto> Reviews { get; set; }
    
}