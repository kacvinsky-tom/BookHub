using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Enum;

namespace WebMVC.Areas.Admin.ViewModels.Order;

public class OrderCreateViewModel
{
    [Required]
    public OrderStatus Status { get; set; }

    [Required]
    [Display(Name = "User")]
    public int UserId { get; set; }
}
