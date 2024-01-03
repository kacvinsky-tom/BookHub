using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.Order;

public class OrderItemCreateViewModel
{
    [Required]
    public int OrderId { get; set; }

    [Required]
    [Display(Name = "Book")]
    public int BookId { get; set; }

    [Required]
    public int Quantity { get; set; }
}
