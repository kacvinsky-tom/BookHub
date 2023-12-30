using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.Genre;

public class GenreSelectViewModel
{
    [Required]
    public int Id { get; set; }
}
