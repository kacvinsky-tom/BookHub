namespace BookHub.API.InputType;

public class BookInput
{
    public string Title { get; set; }

    public string ISBN { get; set; }

    public string Description { get; set; }

    public string? Image { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public string Publisher { get; set; }

    public int ReleaseYear { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public int AuthorId { get; set; }
    
    public IEnumerable<int> GenreIds { get; set; } = new List<int>();
}