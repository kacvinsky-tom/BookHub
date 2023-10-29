using BookHub.API.DTO.Output;
using BookHub.API.DTO.Output.Book;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public class BookMapper
{
    public static BookListOutputDto MapList(Book book)
    {
        return new BookListOutputDto()
        {
            Id = book.Id,
            Title = book.Title,
            Authors = book.Authors.Select(AuthorMapper.MapList).ToList(),
            Genres = book.Genres.Select(GenreMapper.MapList).ToList(),
            Price = book.Price,
            ReleaseYear = book.ReleaseYear,
        };
    }

    public static BookListWithoutAuthorOutputDto MapListWithoutAuthor(Book book)
    {
        return new BookListWithoutAuthorOutputDto()
        {
            Id = book.Id,
            Title = book.Title,
            Price = book.Price,
            ReleaseYear = book.ReleaseYear,
        };
    }
    
    public static BookDetailOutputDto MapDetail(Book book)
    {
        return new BookDetailOutputDto()
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            Description = book.Description,
            Image = book.Image,
            Price = book.Price,
            Quantity = book.Quantity,
            Publisher = PublisherMapper.MapDetail(book.Publisher),
            ReleaseYear = book.ReleaseYear,
            Authors = book.Authors.Select(AuthorMapper.MapList).ToList(),
            Genres = book.Genres.Select(GenreMapper.MapList).ToList(),
            Reviews = book.Reviews.Select(ReviewMapper.MapList).ToList()
        };
    }
}