using System.ComponentModel.DataAnnotations;
using Core.DTO.Output;

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
    
    [Display(Name = "ImageData")]
    public IFormFile? ImageData { get; set; }
    
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
    [Display(Name = "Publisher")]
    public int PublisherId { get; set; }

    [Required]
    [Display(Name = "Authors")]
    public List<int> AuthorIds { get; set; } = new();

    [Required]
    [Display(Name = "Genres")]
    public List<int> GenreIds { get; set; } = new();

    [Required]
    [Display(Name = "Primary genre")]
    public int PrimaryGenreId { get; set; }

    public IEnumerable<SimpleListDto> Genres { get; set; } = new List<SimpleListDto>();

    public IEnumerable<SimpleListDto> Authors { get; set; } = new List<SimpleListDto>();

    public IEnumerable<SimpleListDto> Publishers { get; set; } = new List<SimpleListDto>();
}
