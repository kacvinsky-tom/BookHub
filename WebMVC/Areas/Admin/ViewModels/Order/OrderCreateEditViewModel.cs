using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Entity;
using DataAccessLayer.Enum;

namespace WebMVC.Areas.Admin.ViewModels.Order;

public class OrderCreateEditViewModel
{
    [Required]
    public OrderStatus Status { get; set; }

    [Required]
    public DataAccessLayer.Entity.User User { get; set; } = null!;

    public Voucher? VoucherUsed { get; set; }

    [Required]
    public IEnumerable<OrderItemCreateEditViewModel> OrderItems { get; set; } =
        new List<OrderItemCreateEditViewModel>();
}
