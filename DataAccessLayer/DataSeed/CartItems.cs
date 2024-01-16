using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class CartItems
{
    public static IEnumerable<CartItem> PrepareModels()
    {
        var cartItems = new List<CartItem>
        {
            new()
            {
                Id = 1,
                BookId = 7,
                UserId = 4,
                Quantity = 1,
            },
            new()
            {
                Id = 2,
                BookId = 1,
                UserId = 4,
                Quantity = 2,
            },
            new()
            {
                Id = 3,
                BookId = 2,
                UserId = 2,
                Quantity = 1,
            }
        };
        cartItems.ForEach(cartItem =>
            cartItem.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return cartItems;
    }
}
