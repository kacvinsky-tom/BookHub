using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.Genre;

public class GenreCreateEditViewModel
{
    [Microsoft.Build.Framework.Required]
    [DataType(DataType.Text)]
    public string Name { get; set; } = "";
}
