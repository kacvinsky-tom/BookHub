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
                Title = "Harry Potter and the Deathly Hallows",
                ISBN = "9781781100264",
            },
            new()
            {
                Id = 2,
                OrderId = 1,
                BookId = 11,
                Quantity = 1,
                Price = 399,
                Title = "Harry Potter and the Cursed Child",
                ISBN = "9780751565362",
            },
            new()
            {
                Id = 3,
                OrderId = 2,
                BookId = 3,
                Quantity = 1,
                Price = 699,
                Title = "A Game of Thrones",
                ISBN = "9780553897845",
            },
            new()
            {
                Id = 4,
                OrderId = 3,
                BookId = 1,
                Quantity = 1,
                Price = 399,
                Title = "The Color of Magic",
                ISBN = "9780060855925",
            }
        };
        orderItems.ForEach(orderItem =>
            orderItem.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return orderItems;
    }
}
