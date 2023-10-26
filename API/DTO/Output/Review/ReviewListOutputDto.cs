namespace BookHub.API.DTO.Output.Review;

public class ReviewListOutputDto : OutputDtoBase
{
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string BookTitle { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
}