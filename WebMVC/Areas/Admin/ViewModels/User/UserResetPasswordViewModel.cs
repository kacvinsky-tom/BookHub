using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.User;

public class UserResetPasswordViewModel
{
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; } = null!;
}
