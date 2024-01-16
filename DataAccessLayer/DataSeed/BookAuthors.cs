using DataAccessLayer.Entity;

namespace DataAccessLayer.DataSeed;

internal static class BookAuthors
{
    public static IEnumerable<BookAuthor> PrepareRelations()
    {
        return new List<BookAuthor>
        {
            new() { BookId = 1, AuthorId = 1 },
            new() { BookId = 1, AuthorId = 2 },
            new() { BookId = 2, AuthorId = 3 },
            new() { BookId = 2, AuthorId = 4 },
            new() { BookId = 3, AuthorId = 1 },
            new() { BookId = 3, AuthorId = 2 },
            new() { BookId = 3, AuthorId = 3 },
            new() { BookId = 4, AuthorId = 4 },
            new() { BookId = 4, AuthorId = 1 },
            new() { BookId = 4, AuthorId = 2 },
            new() { BookId = 4, AuthorId = 3 },
            new() { BookId = 5, AuthorId = 4 },
            new() { BookId = 5, AuthorId = 1 },
            new() { BookId = 6, AuthorId = 2 },
            new() { BookId = 6, AuthorId = 3 },
            new() { BookId = 7, AuthorId = 4 },
            new() { BookId = 7, AuthorId = 1 },
            new() { BookId = 8, AuthorId = 2 },
            new() { BookId = 8, AuthorId = 3 },
            new() { BookId = 9, AuthorId = 4 },
            new() { BookId = 9, AuthorId = 1 },
            new() { BookId = 10, AuthorId = 2 },
            new() { BookId = 10, AuthorId = 3 },
            new() { BookId = 11, AuthorId = 4 },
            new() { BookId = 11, AuthorId = 1 },
        };
    }
}
