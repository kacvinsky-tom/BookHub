using Core.DTO.Input.Review;
using DataAccessLayer.Entity;

namespace Tests.Utilities.Data;

public static class ReviewTestData
{
    public static IEnumerable<Review> GetFakeReviews()
    {
        return new List<Review>
        {
            new()
            {
                Id = 1,
                Rating = 5,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 1,
                Comment = "Review 1",
            },
            new()
            {
                Id = 2,
                Rating = 4,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = 2,
                Comment = "Review 2",
            },
        };
    }

    public static ReviewCreateInputDto GetFakeReviewCreateInputDto()
    {
        return new()
        {
            Rating = 5,
            Comment = "Review 1",
            BookId = 1,
            UserId = 1,
        };
    }

    public static ReviewUpdateInputDto GetFakeReviewUpdateInputDto()
    {
        return new() { Rating = 5, Comment = "Review 1", };
    }
}
