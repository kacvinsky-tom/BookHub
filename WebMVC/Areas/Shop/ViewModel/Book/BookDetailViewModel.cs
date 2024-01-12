using WebMVC.Areas.Shop.ViewModel.Review;

namespace WebMVC.Areas.Shop.ViewModel.Book;

public class BookDetailViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string ISBN { get; set; } = "";

    public string Description { get; set; } = "";

    public string? Image { get; set; }

    public int Price { get; set; }

    public int ReleaseYear { get; set; }

    public List<ReviewDetailViewModel> Reviews { get; set; } = new();
}
