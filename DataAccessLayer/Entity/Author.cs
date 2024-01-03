namespace DataAccessLayer.Entity;

public class Author : BaseEntity
{
    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public IEnumerable<Book> Books { get; } = new List<Book>();

    public IEnumerable<BookAuthor> BookAuthors { get; } = new List<BookAuthor>();
}
