using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.Author;

public class AuthorCreateViewModel
{
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "First name")]
    public string FirstName { get; set; } = "";

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Last name")]
    public string LastName { get; set; } = "";
}
