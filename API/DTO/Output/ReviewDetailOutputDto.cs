namespace BookHub.API.DTO.Output;

public class ReviewDetailOutputDto : OutputDtoBase
{

    public UserDetailOutputDto User { get; set; }
    
    // TODO uncomment this when BookListOutputDto is implemented
    // public BookListOutputDto Book { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}