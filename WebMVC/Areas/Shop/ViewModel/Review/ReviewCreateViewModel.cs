using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Shop.ViewModel.Review;

public class ReviewCreateViewModel
{
    [Required]
    public int BookId { get; set; }

    [Required]
    public string Comment { get; set; } = "";

    [Required]
    public int Rating { get; set; }
}
