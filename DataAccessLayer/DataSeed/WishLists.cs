using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class WishLists
{
    public static IEnumerable<WishList> PrepareModels()
    {
        var wishlists = new List<WishList>
        {
            new()
            {
                Id = 1,
                Name = "Můj seznam přání",
                UserId = 2,
            },
            new()
            {
                Id = 2,
                Name = "Zbývající harry potter knížky",
                UserId = 2,
            },
        };
        wishlists.ForEach(wishlist =>
            wishlist.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return wishlists;
    }
}
