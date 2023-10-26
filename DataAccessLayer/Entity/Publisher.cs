namespace BookHub.DataAccessLayer.Entity;

public class Publisher : BaseEntity
{
    public string Name { get; set; }
    
    public string State { get; set; }
    
    public string Email { get; set; }
}