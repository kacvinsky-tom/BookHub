using System.ComponentModel.DataAnnotations;

namespace BookHub.DataAccessLayer.Entity;

public class User : BaseEntity 
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public bool IsAdmin { get; set; } = false;
}