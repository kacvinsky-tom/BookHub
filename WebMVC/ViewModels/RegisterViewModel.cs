using System.ComponentModel.DataAnnotations;

namespace WebMVC.ViewModels;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Username { get; set; }

    [Required]
    [DataType((DataType.Text))]
    public string FirstName { get; set; }

    [Required]
    [DataType((DataType.Text))]
    public string LastName { get; set; }

    [Required]
    [DataType((DataType.PhoneNumber))]
    public string PhoneNumber { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
