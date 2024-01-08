using DataAccessLayer.Entity;

namespace Tests.Utilities.Data;

public static class AuthorTestData
{
    public static IEnumerable<Author> GetFakeAuthors()
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
            },
        };
    }
}
