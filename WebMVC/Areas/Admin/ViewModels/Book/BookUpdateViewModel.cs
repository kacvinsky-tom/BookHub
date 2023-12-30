using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.Book;

public class BookUpdateViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Title { get; set; } = "";

    [Required]
    [DataType(DataType.Text)]
    public string ISBN { get; set; } = "";

    [Required]
    [DataType(DataType.Text)]
    public string Description { get; set; } = "";

    [DataType(DataType.Url)]
    [Display(Name = "Image URL (optional)")]
    public string? Image { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public int Price { get; set; }

    [Required]
    [Display(Name = "Initial quantity in stock")]
    public int Quantity { get; set; }

    [Required]
    [Display(Name = "Year of release")]
    public int ReleaseYear { get; set; }

    [Required]
    public int PublisherId { get; set; }

    [Required]
    public List<int> AuthorIds { get; set; } = new();

    [Required]
    public List<int> GenreIds { get; set; } = new();
}
