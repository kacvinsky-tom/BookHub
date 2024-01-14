using WebMVC.ViewModels;

namespace WebMVC.Areas.Shop.ViewModel.WishList;

public class WishListItemListViewModel
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string BookTitle { get; set; } = "";
    public IEnumerable<AuthorListViewModel> BookAuthors { get; set; } =
        new List<AuthorListViewModel>();
    public string? BookImage { get; set; }
    public decimal BookPrice { get; set; }
}
