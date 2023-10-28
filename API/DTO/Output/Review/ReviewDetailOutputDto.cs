using BookHub.API.DTO.Output.Book;
using BookHub.API.DTO.Output.User;

namespace BookHub.API.DTO.Output.Review;

public class ReviewDetailOutputDto : OutputDtoBase
{

    public UserListOutputDto User { get; set; }
    public BookListOutputDto Book { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}