using Core.DTO.Output.Author;
using Core.DTO.Output.Book;
using Core.DTO.Output.Genre;

namespace WebMVC.ViewModels;

public class SearchListViewModel
{
    public required string Query;
    public required IEnumerable<AuthorListViewModel> Authors { get; set; }
    public required IEnumerable<GenreListViewModel> Genres { get; set; }
    public required IEnumerable<BookListViewModel> Books { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
