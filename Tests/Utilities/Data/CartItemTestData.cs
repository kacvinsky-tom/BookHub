using DataAccessLayer.Entity;

namespace Tests.Utilities.Data;

public static class CartItemTestData
{
    public static IEnumerable<CartItem> GetFakeCartItems()
    {
        return new List<CartItem>()
        {
            new()
            {
                Id = 1,
                BookId = 1,
                UserId = 1,
                Quantity = 1,
            },
            new()
            {
                Id = 2,
                BookId = 2,
                UserId = 2,
                Quantity = 2,
            },
            new()
            {
                Id = 3,
                BookId = 2,
                UserId = 1,
                Quantity = 3,
            }
        };
    }

    public static IEnumerable<Book> GetFakeCartItemBooks()
    {
        return new List<Book>()
        {
            new()
            {
                Id = 1,
                Authors = new List<Author>()
                {
                    new()
                    {
                        Id = 1,
                        FirstName = "John",
                        LastName = "Doe"
                    }
                },
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
        };
    }

    public static IEnumerable<User> GetFakeCartItemUsers()
    {
        return new List<User>()
        {
            new()
            {
                Id = 1,
                Username = "johndoe",
                Email = "john@do.ee",
                Password = "123456",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890",
                IsAdmin = false
            }
        };
    }
}
