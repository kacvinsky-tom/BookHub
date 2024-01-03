using DataAccessLayer.Entity;
using DataAccessLayer.Enum;

namespace Tests.Utilities.Data;

public class OrderTestData
{
    public static IEnumerable<Order> GetFakeOrders()
    {
        return new List<Order>
        {
            new()
            {
                Id = 1,
                UserId = 1,
                TotalPrice = 100,
                Status = OrderStatus.Pending,
                User = new User
                {
                    Id = 1,
                    Username = "user1",
                    Email = "test@example.org",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "123456789",
                }
            },
            new()
            {
                Id = 2,
                UserId = 2,
                TotalPrice = 200,
                Status = OrderStatus.Pending,
                User = new User
                {
                    Id = 2,
                    Username = "user2",
                    Email = "test@example.org",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "123456789",
                }
            },
        };
    }
}
