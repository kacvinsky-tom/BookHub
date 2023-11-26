using Core.DTO.Input.User;
using DataAccessLayer.Entity;

namespace Tests.Utilities.Data;

public class UserTestData
{
    public static IEnumerable<User> GetFakeUsers()
    {
        return new List<User>
        {
            new()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "test@example.org",
                Password = "password",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new()
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "test@example.org",
                Password = "password",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
        };
    }

    public static UserInputDto GetFakeUserInputDto()
    {
        return new()
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "test@eamil.com",
            Password = "password"
        };
    }
}