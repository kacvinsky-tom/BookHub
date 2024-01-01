using System.ComponentModel.DataAnnotations;

namespace WebMVC.ViewModels;

public class OrderViewModel
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public string? OrderStatus { get; set; }
}
