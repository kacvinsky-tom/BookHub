namespace Core.DTO.Output.Genre;

public class BookGenreListOutputDto
{
    public int GenreId { get; set; }
    public string GenreName { get; set; } = "";
    public bool IsPrimary { get; set; } = false;
}
