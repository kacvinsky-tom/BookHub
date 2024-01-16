using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class WishListItems
{
    public static IEnumerable<WishListItem> PrepareModels()
    {
        var wishlistItems = new List<WishListItem>
        {
            new()
            {
                Id = 1,
                WishListId = 1,
                BookId = 1,
            },
            new()
            {
                Id = 2,
                WishListId = 1,
                BookId = 3,
            },
            new()
            {
                Id = 3,
                WishListId = 2,
                BookId = 8,
            },
            new()
            {
                Id = 4,
                WishListId = 2,
                BookId = 9,
            },
            new()
            {
                Id = 5,
                WishListId = 2,
                BookId = 10,
            },
            new()
            {
                Id = 6,
                WishListId = 2,
                BookId = 11,
            },
        };
        wishlistItems.ForEach(wishlistItem =>
            wishlistItem.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return wishlistItems;
    }
}
