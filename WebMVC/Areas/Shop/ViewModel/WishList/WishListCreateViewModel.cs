using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Shop.ViewModel.WishList;

public class WishListCreateViewModel
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public string Name { get; set; } = "";
}
