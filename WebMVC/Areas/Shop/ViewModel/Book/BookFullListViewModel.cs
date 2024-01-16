using WebMVC.Areas.Shop.ViewModel.BookGenre;
using WebMVC.ViewModels;

namespace WebMVC.Areas.Shop.ViewModel.Book;

public class BookFullListViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = "";
    public int ReleaseYear { get; set; }

    public string Price { get; set; } = "";

    public string? Image { get; set; } = null;

    public List<AuthorListViewModel> Authors { get; set; } = new();

    public List<BookGenreListViewModel> BookGenres { get; set; } = new();
}
