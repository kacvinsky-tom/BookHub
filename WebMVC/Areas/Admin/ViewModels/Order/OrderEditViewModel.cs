using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Entity;
using DataAccessLayer.Enum;

namespace WebMVC.Areas.Admin.ViewModels.Order;

public class OrderEditViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public OrderStatus Status { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public List<OrderItem> OrderItems { get; set; } = new();
}
