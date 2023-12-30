using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.Author;

public class AuthorSelectViewModel
{
    [Required]
    public int Id { get; set; }
}