using System.Security.Claims;
using AutoMapper;
using Core.DTO.Input.CartItem;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Shop.ViewModel.CartItem;

namespace WebMVC.Areas.Shop.Controllers;

[Area("Shop")]
public class CartController : Controller
{
    private readonly BookService _bookService;
    private readonly CartService _cartService;
    private readonly UserService _userService;
    private readonly IMapper _mapper;

    public CartController(BookService bookService, CartService cartService, UserService userService, IMapper mapper)
    {
        _bookService = bookService;
        _cartService = cartService;
        _userService = userService;
        _mapper = mapper;
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

        var cartItems = await _cartService.GetCartItemsByUserId(currentUser.Id);
        
        var cartItemViewModels = _mapper.Map<IEnumerable<CartItemViewModel>>(cartItems);

        return View(cartItemViewModels);
    }
    
    public async Task<IActionResult> Add(int id)
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

        var currentUserId = currentUser.Id;
        
        var book = await _bookService.GetById(id);

        if (book == null)
        {
            return NotFound();
        }

        await _cartService.CreateCartItem(new CartItemCreateInputDto
        {
            BookId = book.Id,
            UserId = currentUserId,
            Quantity = 1
        });
        
        return RedirectToAction(nameof(Index), nameof(CartController).Replace("Controller", ""));
    }
}