using BookHub.DTO.Output.Book;
using BookHub.DTO.Output.User;

namespace BookHub.DTO.Output.Review;

public class ReviewDetailOutputDto : OutputDtoBase
{
    public UserDetailOutputDto User { get; set; }
    public BookListOutputDto Book { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}