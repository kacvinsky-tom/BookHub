using BookHub.API.DTO.Output.Book;

namespace BookHub.API.DTO.Output.CartItem;

public class CartItemOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    // TODO Unwrap only needed info about book detail, probably BookListDto and collections of GenreDto and AuthorDto
    public BookListOutputDto BookDetail { get; set; }
}