using BookHub.API.DTO.Output;
using BookHub.DataAccessLayer.Dtos;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public class ReviewMapper
{
    public static ReviewListOutputDto MapList(Review review)
    {
        return new ReviewListOutputDto()
        {
            Id = review.Id,
            UserFirstName = review.User?.FirstName,
            UserLastName = review.User?.LastName,
            BookTitle = review.Book?.Title,
            Comment = review.Comment,
            Rating = review.Rating,
            CreatedAt = review.CreatedAt
        };
    }
    
    public static ReviewDetailOutputDto MapDetail(Review review)
    {
        return new ReviewDetailOutputDto()
        {
            Id = review.Id,
            User = UserMapper.MapDetail(review.User),
            // TODO uncomment after implementing book detail
            //Book = BookMapper.MapList(review.Book),
            Comment = review.Comment,
            Rating = review.Rating,
            CreatedAt = review.CreatedAt
        };
    }
}