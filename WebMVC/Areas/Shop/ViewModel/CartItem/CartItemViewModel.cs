namespace WebMVC.Areas.Shop.ViewModel.CartItem;

public class CartItemViewModel
{
    public int Id { get; set; }
    
    public string BookTitle { get; set; } = null!;

    public int Quantity { get; set; }
}
