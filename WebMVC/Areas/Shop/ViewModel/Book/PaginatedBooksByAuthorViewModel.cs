using WebMVC.ViewModels;

namespace WebMVC.Areas.Shop.ViewModel.Book;

public class PaginatedBooksByAuthorViewModel : PaginationViewModel<BookFullListViewModel>
{
    public int AuthorId { get; set; }
    public string AuthorDisplayName { get; set; } = "";
}
