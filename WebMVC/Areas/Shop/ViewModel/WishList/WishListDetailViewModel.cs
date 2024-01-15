namespace WebMVC.Areas.Shop.ViewModel.WishList;

public class WishListDetailViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = "";
    public IEnumerable<WishListItemListViewModel> WishListItems { get; set; } =
        new List<WishListItemListViewModel>();
}
