using System.ComponentModel.DataAnnotations;

namespace WebMVC.ViewModels;

public class SettingsChangeInfoViewModel
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
}
