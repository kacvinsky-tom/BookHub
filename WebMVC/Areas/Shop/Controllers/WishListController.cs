using System.Security.Claims;
using AutoMapper;
using Core.DTO.Input.WishList;
using Core.DTO.Input.WishListItem;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Shop.ViewModel.WishList;

namespace WebMVC.Areas.Shop.Controllers;

[Area("Shop")]
[Authorize]
public class WishListController : Controller
{
    private readonly WishListService _wishListService;
    private readonly UserService _userService;
    private readonly IMapper _mapper;

    public WishListController(
        WishListService wishListService,
        IMapper mapper,
        UserService userService
    )
    {
        _wishListService = wishListService;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var currentUserUsername = User.FindFirst(ClaimTypes.Name)?.Value;
        if (currentUserUsername == null)
        {
            return NotFound();
        }

        var currentUser = _userService.GetByUsername(currentUserUsername).Result;
        if (currentUser == null)
        {
            return NotFound();
        }

        var wishLists = await _wishListService.GetAllForUser(currentUser.Id);

        return View(
            new WishListListPageViewModel()
            {
                UserId = currentUser.Id,
                WishLists = _mapper.Map<IEnumerable<WishListListViewModel>>(wishLists)
            }
        );
    }

    [HttpPost]
    [Route("/Shop/WishList/Create")]
    public async Task<IActionResult> Create(WishListCreateViewModel wishListCreateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        var wishList = await _wishListService.Create(
            _mapper.Map<WishListInputDto>(wishListCreateViewModel)
        );

        return RedirectToAction("Detail", new { id = wishList.Id });
    }

    [HttpPost]
    [Route("/Shop/WishList/Edit/")]
    public async Task<IActionResult> Edit(WishListEditViewModel wishListEditViewModel)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        try
        {
            await _wishListService.Update(
                _mapper.Map<WishListInputDto>(wishListEditViewModel),
                wishListEditViewModel.WishListId
            );
        }
        catch (NotFoundException e)
        {
            return NotFound("Wishlist not found");
        }

        TempData["Success"] = "Wishlist updated successfully";
        return RedirectToAction("Detail", new { id = wishListEditViewModel.WishListId });
    }

    [HttpPost]
    [Route("/Shop/WishList/Delete/{wishListId}")]
    public async Task<IActionResult> Delete(int wishListId)
    {
        try
        {
            await _wishListService.Delete(wishListId);
        }
        catch (NotFoundException e)
        {
            return NotFound("Wishlist not found");
        }

        TempData["Success"] = "Wishlist deleted successfully";
        return RedirectToAction("Index");
    }

    [Route("/Shop/WishList/Detail/{id}")]
    public async Task<IActionResult> Detail(int id)
    {
        var wishList = await _wishListService.GetById(id);

        if (wishList == null)
        {
            return NotFound();
        }

        return View(_mapper.Map<WishListDetailViewModel>(wishList));
    }

    [HttpPost]
    [Route("/Shop/WishList/AddToWishList")]
    public async Task<IActionResult> AddToWishList(
        WishListItemsEditViewModel itemsEditWishListItemsViewModel
    )
    {
        try
        {
            await _wishListService.CreateItemInWishlist(
                _mapper.Map<WishListItemInputDto>(itemsEditWishListItemsViewModel)
            );
        }
        catch (NotFoundException e)
        {
            TempData["Error"] = "Failed to add wishlist item";
            return RedirectToAction(
                "Detail",
                "WishList",
                new { id = itemsEditWishListItemsViewModel.WishListId }
            );
        }
        catch (AlreadyExistsException e)
        {
            TempData["Error"] = $"Failed to add wishlist item: {e.Message}";
            return RedirectToAction(
                "Detail",
                "WishList",
                new { id = itemsEditWishListItemsViewModel.WishListId }
            );
        }

        TempData["Success"] = "Book added to wishlist successfully";
        return RedirectToAction(
            "Detail",
            "WishList",
            new { id = itemsEditWishListItemsViewModel.WishListId }
        );
    }

    [HttpPost]
    [Route("/Shop/WishList/RemoveFromWishList")]
    public async Task<IActionResult> RemoveFromWishList(
        WishListItemsEditViewModel itemsEditWishListItemsViewModel
    )
    {
        try
        {
            await _wishListService.DeleteItemByBookAndWishListId(
                itemsEditWishListItemsViewModel.BookId,
                itemsEditWishListItemsViewModel.WishListId
            );
        }
        catch (NotFoundException e)
        {
            return NotFound("Item not found");
        }

        TempData["Success"] = "Book removed from wishlist successfully";
        return RedirectToAction(
            "Detail",
            "WishList",
            new { id = itemsEditWishListItemsViewModel.WishListId }
        );
    }
}
