using DataAccessLayer.Entity;
using DataAccessLayer.Enum;

namespace DataAccessLayer.DataSeed;

internal static class Orders
{
    public static IEnumerable<Order> PrepareModels()
    {
        var orders = new List<Order>
        {
            new()
            {
                Id = 1,
                UserId = 3,
                Status = OrderStatus.Pending,
                TotalPrice = 798
            },
            new()
            {
                Id = 2,
                UserId = 4,
                Status = OrderStatus.Completed,
                TotalPrice = 699
            },
            new()
            {
                Id = 3,
                UserId = 2,
                Status = OrderStatus.Cancelled,
                TotalPrice = 399
            }
        };
        orders.ForEach(order =>
            order.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return orders;
    }
}
