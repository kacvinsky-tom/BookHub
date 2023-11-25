using DataAccessLayer.Entity;

namespace Tests.Utilities.Data;

public static class GenreTestData
{
    public static IEnumerable<Genre> GetFakeGenres()
    {
        return new List<Genre>()
        {
            new() { Id = 1, Name = "Comedy", },
            new() { Id = 2, Name = "Tragedy", },
            new() { Id = 3, Name = "Drama", },
            new() { Id = 4, Name = "Romance", },
        };
    }
}
