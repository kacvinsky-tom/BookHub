namespace WebMVC.Areas.Shop.ViewModel.WishList;

public class WishListListPageViewModel
{
    public int UserId { get; set; }
    public IEnumerable<WishListListViewModel> WishLists { get; set; } =
        new List<WishListListViewModel>();
}
