using BookHub.API.DTO.Output.Publisher;
using BookHub.API.DTO.Output.Review;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.DTO.Output;

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
    
    public ICollection<Genre> Genres { get; set; }
    
    public IEnumerable<ReviewListOutputDto> Reviews { get; set; }
    
    // TODO Move definition from BookMapper.cs and modify mapper to use this and List Dtos
    // TODO Add AuthorDto and GenreDto collections after they are implemented
}