using BookHub.DataAccessLayer.Entity;

namespace BookHub.Mapper;

public static class BookMapper
{
    public static object Map(Book book)
    {
        return new
        {
            book.Id,
            book.Title,
            book.ISBN,
            book.Description,
            book.Image, //TODO how are we going to handle images?
            book.Price,
            book.Quantity,
            book.Publisher,
            book.ReleaseYear,
            Author = new
            {
                book.Author.Id,
                book.Author.FirstName,
                book.Author.LastName
            },
            Genres = book.Genres.Select(genre => new
            {
                genre.Id, genre.Name
            }),
            Reviews = book.Reviews.Select(review => new
            {
                review.Id,
                review.Rating,
                review.Comment,
                review.CreatedAt,
                User = new
                {
                    review.User.Id,
                    review.User.FirstName,
                    review.User.LastName
                }
            })
        };
    }
}