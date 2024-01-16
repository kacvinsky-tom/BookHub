using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class BookGenres
{
    public static IEnumerable<BookGenre> PrepareRelations()
    {
        return new List<BookGenre>
        {
            new()
            {
                BookId = 1,
                GenreId = 2,
                IsPrimary = true
            },
            new() { BookId = 1, GenreId = 8 },
            new()
            {
                BookId = 2,
                GenreId = 2,
                IsPrimary = true
            },
            new() { BookId = 2, GenreId = 8 },
            new()
            {
                BookId = 3,
                GenreId = 2,
                IsPrimary = true
            },
            new() { BookId = 3, GenreId = 8 },
            new() { BookId = 3, GenreId = 9 },
            new()
            {
                BookId = 4,
                GenreId = 1,
                IsPrimary = true
            },
            new() { BookId = 4, GenreId = 5 },
            new() { BookId = 4, GenreId = 6 },
            new() { BookId = 4, GenreId = 7 },
            new()
            {
                BookId = 5,
                GenreId = 2,
                IsPrimary = true
            },
            new() { BookId = 5, GenreId = 8 },
            new()
            {
                BookId = 6,
                GenreId = 2,
                IsPrimary = true
            },
            new() { BookId = 6, GenreId = 8 },
            new()
            {
                BookId = 7,
                GenreId = 2,
                IsPrimary = true
            },
            new() { BookId = 7, GenreId = 8 },
            new()
            {
                BookId = 8,
                GenreId = 2,
                IsPrimary = true
            },
            new() { BookId = 8, GenreId = 8 },
            new()
            {
                BookId = 9,
                GenreId = 2,
                IsPrimary = true
            },
            new() { BookId = 9, GenreId = 8 },
            new()
            {
                BookId = 10,
                GenreId = 2,
                IsPrimary = true
            },
            new() { BookId = 10, GenreId = 8 },
            new()
            {
                BookId = 11,
                GenreId = 2,
                IsPrimary = true
            },
            new() { BookId = 11, GenreId = 8 },
        };
    }
}
