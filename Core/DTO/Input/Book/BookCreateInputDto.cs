namespace Core.DTO.Input.Book;

public class BookCreateInputDto
{
    public string Title { get; set; } = "";

    public string ISBN { get; set; } = "";

    public string Description { get; set; } = "";

    public string? Image { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public int ReleaseYear { get; set; }

    public int PublisherId { get; set; }

    public IEnumerable<int> AuthorIds { get; set; } = new List<int>();

    public IEnumerable<int> GenreIds { get; set; } = new List<int>();
}
