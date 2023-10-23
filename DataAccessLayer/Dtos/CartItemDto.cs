namespace BookHub.DataAccessLayer.Dtos;

public class CartItemDto : DtoBase
{
    public int Quantity { get; set; }
    // TODO Unwrap only needed info about book detail, probably BookListDto and collections of GenreDto and AuthorDto
    public BookListDto BookDetail { get; set; }
}