using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.Book;

public class BookCreateEditViewModel
{
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
    public string? Image { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    [Display(Name = "Year of release")]
    public int ReleaseYear { get; set; }

    [Required]
    public DataAccessLayer.Entity.Publisher Publisher { get; set; } = new();

    [Required]
    public IEnumerable<DataAccessLayer.Entity.Author> Authors { get; set; } =
        new List<DataAccessLayer.Entity.Author>();

    [Required]
    public IEnumerable<DataAccessLayer.Entity.Genre> Genres { get; set; } =
        new List<DataAccessLayer.Entity.Genre>();
}
