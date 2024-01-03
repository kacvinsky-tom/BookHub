using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.Genre;

public class GenreCreateViewModel
{
    [Microsoft.Build.Framework.Required]
    [DataType(DataType.Text)]
    public string Name { get; set; } = "";
}
