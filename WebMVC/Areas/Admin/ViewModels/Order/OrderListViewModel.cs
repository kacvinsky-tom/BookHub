using DataAccessLayer.Enum;

namespace WebMVC.Areas.Admin.ViewModels.Order;

public class OrderListViewModel
{
    public int Id { get; set; }
    
    public int TotalPrice { get; set; }

    public OrderStatus Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string UserFullName { get; set; } = null!;
    
    public int ItemsCount { get; set; }
}