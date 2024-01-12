namespace WebMVC.Areas.Shop.ViewModel.Review;

public class ReviewDetailViewModel
{
    public int Id { get; set; }

    public string Comment { get; set; } = "";

    public int Rating { get; set; }

    public string UserUsername { get; set; } = "";

    public string UserFirstName { get; set; } = "";

    public string UserLastName { get; set; } = "";

    public DateTime CreatedAt { get; set; }
}
