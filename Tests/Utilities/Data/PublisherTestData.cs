using Core.DTO.Input.Publisher;
using DataAccessLayer.Entity;

namespace Tests.Utilities.Data;

public class PublisherTestData
{
    public static IEnumerable<Publisher> GetFakePublishers()
    {
        return new List<Publisher>()
        {
            new() { Id = 1, Name = "Publisher 1", },
            new() { Id = 2, Name = "Publisher 2", },
            new() { Id = 3, Name = "Publisher 3", },
            new() { Id = 4, Name = "Publisher 4", },
        };
    }

    public static PublisherInputDto GetFakePublisherInputDto()
    {
        return new() { Name = "Publisher 1", };
    }
}
