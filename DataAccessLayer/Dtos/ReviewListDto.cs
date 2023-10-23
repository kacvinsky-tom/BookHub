namespace BookHub.DataAccessLayer.Dtos;

public class ReviewListDto : DtoBase
{
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public int BookName { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}