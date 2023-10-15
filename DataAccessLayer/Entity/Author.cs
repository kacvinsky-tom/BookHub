namespace BookHub.DataAccessLayer.Entity;

public class Author: BaseEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public ICollection<Book> Books { get; } = new List<Book>();
}