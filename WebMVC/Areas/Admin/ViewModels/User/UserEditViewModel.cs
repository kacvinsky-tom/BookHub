using System.ComponentModel.DataAnnotations;
using Core.DTO.Output;

namespace WebMVC.Areas.Admin.ViewModels.User;

public class UserEditViewModel
{
    [Required]
    public string Id { get; set; } = "";

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

    [Required]
    public string Role { get; set; } = "User";

    public List<SimpleListDto> AvailableRoles { get; set; } = new List<SimpleListDto>();
}
