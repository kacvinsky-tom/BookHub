using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class Genres
{
    public static IEnumerable<Genre> PrepareModels()
    {
        var genres = new List<Genre>
        {
            new() { Id = 1, Name = "Horror", },
            new() { Id = 2, Name = "Fantasy", },
            new() { Id = 3, Name = "Sci-Fi", },
            new() { Id = 4, Name = "Romance", },
            new() { Id = 5, Name = "Crime", },
            new() { Id = 6, Name = "Mystery", },
            new() { Id = 7, Name = "Thriller", },
            new() { Id = 8, Name = "Adventure", },
            new() { Id = 9, Name = "Action", },
            new() { Id = 10, Name = "Humor and Comedy", },
            new() { Id = 11, Name = "Drama", },
            new() { Id = 12, Name = "Biography", },
            new() { Id = 13, Name = "Historical novels", },
            new() { Id = 14, Name = "Poetry", }
        };
        genres.ForEach(genre =>
            genre.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return genres;
    }
}
