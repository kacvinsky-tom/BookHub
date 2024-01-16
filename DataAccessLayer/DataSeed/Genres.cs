using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class Genres
{
    public static IEnumerable<Genre> PrepareModels()
    {
        var genres = new List<Genre>
        {
            new() { Id = 1, Name = "Horor", },
            new() { Id = 2, Name = "Fantasy", },
            new() { Id = 3, Name = "Sci-Fi", },
            new() { Id = 4, Name = "Romantické", },
            new() { Id = 5, Name = "Krimi", },
            new() { Id = 6, Name = "Mysteriózní", },
            new() { Id = 7, Name = "Thriller", },
            new() { Id = 8, Name = "Dobrodružné", },
            new() { Id = 9, Name = "Akční", },
            new() { Id = 10, Name = "Komedie", },
            new() { Id = 11, Name = "Drama", },
            new() { Id = 12, Name = "Biografie", },
            new() { Id = 13, Name = "Historické romány", },
            new() { Id = 14, Name = "Poezie", }
        };
        genres.ForEach(genre =>
            genre.CreatedAt = new DateTime(2023, 10, 1, 12, 00, 00, DateTimeKind.Utc)
        );
        return genres;
    }
}
