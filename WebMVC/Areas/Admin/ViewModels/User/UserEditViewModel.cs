using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.User;

public class UserEditViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [DataType(DataType.Text)]
    public string Username { get; set; } = "";

    [Required]
    [DataType((DataType.Text))]
    [Display(Name = "First name")]
    public string FirstName { get; set; } = "";

    [Required]
    [DataType((DataType.Text))]
    [Display(Name = "Last name")]
    public string LastName { get; set; } = "";

    [Required]
    [DataType((DataType.PhoneNumber))]
    [Display(Name = "Phone number")]
    public string PhoneNumber { get; set; } = "";

    [DataType(DataType.Password)]
    public string? Password { get; set; } = "";

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; } = "";
}
