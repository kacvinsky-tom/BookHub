using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class Reviews
{
    public static IEnumerable<Review> PrepareModels()
    {
        var reviews = new List<Review>
        {
            new()
            {
                Id = 1,
                BookId = 1,
                UserId = 1,
                Rating = 5,
                Comment =
                    "Terry Pratchett's The Colour of Magic is a brilliant combination of fantasy and humour. Pratchett's ability to create fantastical worlds and humorously comment on our reality is simply incredible. This book is extremely entertaining and profound at the same time.",
            },
            new()
            {
                Id = 2,
                BookId = 1,
                UserId = 2,
                Rating = 5,
                Comment =
                    "When I first read The Colour of Magic, I was amazed by Pratchett's talent. His characters are vivid, the plot is original, and the humor is wonderful. Throughout the book, I laughed at every page.",
            },
            new()
            {
                Id = 3,
                BookId = 1,
                UserId = 3,
                Rating = 4,
                Comment =
                    "Mr. Pratchett created a very interesting place with the Discworld series, populated with very interesting and thoroughly human characters, with all the weaknesses of humans, whose activities are written about in a spirit of tremendous humor. I'm glad to have found the series and will enjoy reading more books in it.",
            },
            new()
            {
                Id = 4,
                BookId = 1,
                UserId = 4,
                Rating = 4,
                Comment =
                    "Terry Pratchett was a genius and The Colour of Magic proves it. His ability to combine fantasy with comedy while brilliantly commenting on various aspects of our society is amazing. This book is a gem and a must for all fans of fantasy and humor.",
            },
            new()
            {
                Id = 5,
                BookId = 7,
                UserId = 1,
                Rating = 5,
                Comment =
                    "Harry Potter and the Goblet of Fire is a turning point in the series. Rowling's ability to develop the world of wizards and characters is amazing. This book is full of suspense, adventure and emotion. I couldn't tear myself away from it.",
            },
            new()
            {
                Id = 6,
                BookId = 7,
                UserId = 2,
                Rating = 4,
                Comment =
                    "Harry Potter and the Goblet of Fire is not only darker than the previous books, but also far more complex. Rowling shows here that her story is not just for children. The plot is suspenseful and the characters go through important changes.",
            },
            new()
            {
                Id = 7,
                BookId = 7,
                UserId = 3,
                Rating = 5,
                Comment =
                    "Harry Potter's fourth adventures in the Goblet of Fire are fantastic. This book features incredible dedication and dueling at the Tournament of Three Spells. Rowling's ability to create a complex and engaging story remains unsurpassed.",
            },
            new()
            {
                Id = 8,
                BookId = 7,
                UserId = 4,
                Rating = 5,
                Comment =
                    "Harry Potter and the Goblet of Fire is further proof of Rowling's brilliant ability to write for a variety of ages. This book is engaging, full of mystery and emotion, and proves why the Harry Potter series is so popular around the world.",
            },
        };
        reviews.ForEach(review =>
            review.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return reviews;
    }
}
