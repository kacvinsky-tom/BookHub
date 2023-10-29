using DataAccessLayer.Filter;

namespace WebAPI.InputType.Filter;

public class BookFilterInput
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public int? PriceFrom { get; set; }
    
    public int? PriceTo { get; set; }

    public IEnumerable<int>? GenreIds { get; set; }

    public string? AuthorName { get; set; }

    public string? PublisherName { get; set; }

    public BookFilter ToBookFilter()
    {
        return new BookFilter
        {
            Title = Title,
            Description = Description,
            PriceFrom = PriceFrom,
            PriceTo = PriceTo,
            GenreIds = GenreIds,
            AuthorName = AuthorName,
            PublisherName = PublisherName
        };
    }
}