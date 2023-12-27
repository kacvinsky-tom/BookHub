using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.Publisher;

public class PublisherCreateEditViewModel
{
    [Required]
    [DataType(DataType.Text)]
    public string Name { get; set; } = "";
}
