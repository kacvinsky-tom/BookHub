using BookHub.API.DTO.Output;

namespace BookHub.DataAccessLayer.Dtos;

public class CartItemOutputDto : OutputDtoBase
{
    public int Quantity { get; set; }
    // TODO Unwrap only needed info about book detail, probably BookListDto and collections of GenreDto and AuthorDto
    public BookListOutputDto BookDetail { get; set; }
}