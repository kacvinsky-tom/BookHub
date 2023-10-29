namespace BookHub.API.DTO.Input;

public class ReviewCreateInputDto
{
    public int BookId { get; set; }
    public int UserId { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}