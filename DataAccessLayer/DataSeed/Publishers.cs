using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class Publishers
{
    public static IEnumerable<Publisher> PrepareModels()
    {
        var publishers = new List<Publisher>
        {
            new()
            {
                Id = 1,
                Name = "Scribner",
                State = "New York",
                Email = "ScribnerPublicity@SimonandSchuster.com"
            },
            new()
            {
                Id = 2,
                Name = "Pottermore Publishing",
                State = "London",
                Email = "help@pottermore.com"
            },
            new()
            {
                Id = 3,
                Name = "Bantam",
                State = "New York",
                Email = "BBDPublicity@randomhouse.com"
            }
        };
        publishers.ForEach(publisher =>
            publisher.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return publishers;
    }
}
