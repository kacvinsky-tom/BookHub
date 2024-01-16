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
                Name = "Talpress",
                State = "Czech Republic",
                Email = "eshop@talpress.cz"
            },
            new()
            {
                Id = 2,
                Name = "Albatros",
                State = "Czech Republic",
                Email = "albatros@albatrosmedia.cz"
            },
            new()
            {
                Id = 3,
                Name = "Argo",
                State = "Czech Republic",
                Email = "argo@argo.cz"
            }
        };
        publishers.ForEach(publisher =>
            publisher.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return publishers;
    }
}
