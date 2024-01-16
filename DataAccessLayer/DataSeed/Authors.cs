using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class Authors
{
    public static IEnumerable<Author> PrepareModels()
    {
        var authors = new List<Author>
        {
            new()
            {
                Id = 1,
                FirstName = "Stephen",
                LastName = "King",
            },
            new()
            {
                Id = 2,
                FirstName = "J. K.",
                LastName = "Rowling",
            },
            new()
            {
                Id = 3,
                FirstName = "George R. R.",
                LastName = "Martin",
            },
            new()
            {
                Id = 4,
                FirstName = "Terry",
                LastName = "Pratchett",
            }
        };
        authors.ForEach(author =>
            author.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return authors;
    }
}
