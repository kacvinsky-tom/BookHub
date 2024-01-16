using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class Users
{
    public static IEnumerable<User> PrepareModels()
    {
        var users = new List<User>
        {
            new()
            {
                Id = 1,
                Username = "john.doe",
                Email = "john.doe@gmail.com",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "752 685 143",
            },
            new()
            {
                Id = 2,
                Username = "jane.doe",
                Email = "jane.doe@gmai.com",
                FirstName = "Jane",
                LastName = "Doe",
                PhoneNumber = "746 692 352",
            },
            new()
            {
                Id = 3,
                Username = "pavel.kraus",
                Email = "pavel.kraus@gmail.com",
                FirstName = "Pavel",
                LastName = "Kraus",
                PhoneNumber = "748 242 562",
            },
            new()
            {
                Id = 4,
                Username = "jarda.novak",
                Email = "jarda@novak.cz",
                FirstName = "Jarda",
                LastName = "Novák",
                PhoneNumber = "742 942 934",
            }
        };
        users.ForEach(user =>
            user.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );

        return users;
    }
}
