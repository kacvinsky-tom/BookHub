using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Admin.ViewModels.Order;

public class OrderItemCreateEditViewModel
{
    [Required]
    public DataAccessLayer.Entity.Book Book { get; set; } = null!;

    [Required]
    public int Quantity { get; set; }
}
