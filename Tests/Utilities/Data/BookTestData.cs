using DataAccessLayer.Entity;

namespace Tests.Utilities.Data;

public static class BookTestData
{
    public static IEnumerable<Book> GetFakeBooks()
    {
        return new List<Book>
        {
            new()
            {
                Id = 1,
                Authors = GetFakeBookAuthors().Take(2),
                Title = "Test Book",
                Description = "Test Description",
                Price = 100,
                ISBN = "1234567890123",
                Quantity = 10,
                ReleaseYear = 2021,
                Publisher = new Publisher { Name = "Test Publisher", Id = 1 },
                Genres = new List<Genre>
                {
                    new() { Name = "Comedy", Id = 1 }
                }
            },
            new()
            {
                Id = 2,
                Authors = GetFakeBookAuthors().Skip(2).Take(2),
                Title = "Test Book 2",
                Description = "Test Description 2",
                Price = 200,
                ISBN = "1234567890124",
                Quantity = 20,
                ReleaseYear = 2022,
                Publisher = new Publisher { Name = "Test Publisher 2", Id = 2 },
                Genres = new List<Genre>
                {
                    new() { Name = "Tragedy", Id = 2 }
                }
            }
        };
    }

    public static IEnumerable<Author> GetFakeBookAuthors()
    {
        return new List<Author>
        {
            new()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            },
            new()
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe"
            },
            new()
            {
                Id = 3,
                FirstName = "John",
                LastName = "Smith"
            },
            new()
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Smith"
            }
        };
    }

    public static IEnumerable<Genre> GetFakeGenres()
    {
        return new List<Genre>
        {
            new() { Id = 1, Name = "Comedy" },
            new() { Id = 2, Name = "Tragedy" },
            new() { Id = 3, Name = "Fantasy" },
            new() { Id = 4, Name = "Horror" }
        };
    }
}
