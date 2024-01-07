using Core.DTO.Output.Book;

namespace WebMVC.ViewModels;

public class SearchViewOutputModel
{
    public required IEnumerable<BookListViewModel> Books { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
