using System.ComponentModel.DataAnnotations;

namespace WebMVC.Areas.Shop.ViewModel.WishList;

public class WishListItemsEditViewModel
{
    [Required]
    public int BookId { get; set; }

    [Required]
    [Display(Name = "Select wishlist")]
    public int WishListId { get; set; }
}
