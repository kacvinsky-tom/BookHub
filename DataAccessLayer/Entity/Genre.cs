namespace DataAccessLayer.Entity;

public class Genre : BaseEntity
{
    public string Name { get; set; }

    public IEnumerable<Book> Books { get; } = new List<Book>();
}
