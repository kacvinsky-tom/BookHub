namespace BookHub.DataAccessLayer.Dtos;

public class DtoBase
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}