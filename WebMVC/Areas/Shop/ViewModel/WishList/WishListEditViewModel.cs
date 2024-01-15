namespace WebMVC.Areas.Shop.ViewModel.WishList;

using System.ComponentModel.DataAnnotations;

public class WishListEditViewModel
{
    [Required]
    public int WishListId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public string Name { get; set; } = "";
}
