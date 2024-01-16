using WebMVC.ViewModels;

namespace WebMVC.Areas.Shop.ViewModel.Book;

public class PaginatedBooksByGenreViewModel : PaginationViewModel<BookFullListViewModel>
{
    public int GenreId { get; set; }
    public string GenreDisplayName { get; set; }
}
