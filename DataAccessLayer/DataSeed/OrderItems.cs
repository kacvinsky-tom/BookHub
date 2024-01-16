using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class OrderItems
{
    public static IEnumerable<OrderItem> PrepareModels()
    {
        var orderItems = new List<OrderItem>
        {
            new()
            {
                Id = 1,
                OrderId = 1,
                BookId = 10,
                Quantity = 1,
                Price = 399,
                Title = "Harry Potter a Relikvie smrti",
                ISBN = "978-80-7197-614-1",
            },
            new()
            {
                Id = 2,
                OrderId = 1,
                BookId = 11,
                Quantity = 1,
                Price = 399,
                Title = "Harry Potter a Prokleté Dítě",
                ISBN = "978-80-7197-613-4",
            },
            new()
            {
                Id = 3,
                OrderId = 2,
                BookId = 3,
                Quantity = 1,
                Price = 699,
                Title = "Hra o trůny",
                ISBN = "978-80-7197-612-7",
            },
            new()
            {
                Id = 4,
                OrderId = 3,
                BookId = 1,
                Quantity = 1,
                Price = 399,
                Title = "Barva kouzel",
                ISBN = "978-80-7197-611-0",
            }
        };
        orderItems.ForEach(orderItem =>
            orderItem.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return orderItems;
    }
}
