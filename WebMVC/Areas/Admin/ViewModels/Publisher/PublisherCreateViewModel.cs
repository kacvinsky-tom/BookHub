using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.Publisher;

public class PublisherCreateViewModel
{
    [Required]
    [DataType(DataType.Text)]
    public string Name { get; set; } = "";

    [Required]
    [DataType(DataType.Text)]
    public string State { get; set; } = "";

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = "";
}
