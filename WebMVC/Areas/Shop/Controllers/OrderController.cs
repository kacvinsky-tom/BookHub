using System.Security.Claims;
using Core.DTO.Input.Order;
using Core.Exception;
using Core.Services;
using DataAccessLayer.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Shop.ViewModel.Order;

namespace WebMVC.Areas.Shop.Controllers;

[Authorize]
[Area("Shop")]
public class OrderController : Controller
{
    private readonly OrderService _orderService;
    private readonly UserService _userService;

    public OrderController(OrderService orderService, UserService userService)
    {
        _orderService = orderService;
        _userService = userService;
    }

    public async Task<IActionResult> History()
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

        var orders = await _orderService.GetAllByUserId(currentUserId);

        var viewModels = orders
            .Select(order => new OrderViewModel
            {
                OrderId = order.Id,
                OrderDate = order.CreatedAt,
                OrderStatus = order.Status.ToString(),
                TotalPrice = order.TotalPrice
            })
            .ToList();

        return View(viewModels);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var order = await _orderService.GetById(id);

        if (order == null)
        {
            return NotFound();
        }

        var viewModel = new OrderDetailViewModel
        {
            OrderId = order.Id,
            OrderDate = order.CreatedAt,
            OrderStatus = order.Status.ToString(),
            TotalPrice = order.TotalPrice,
            OrderedBooks = order.OrderItems
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Pay(int id)
    {
        try
        {
            await _orderService.Update(new OrderUpdateInputDto
            {
                Status = OrderStatus.Completed
            }, id);

            return RedirectToAction(nameof(Detail), new { id });
        }
        catch (NotFoundException)
        {
            ModelState.AddModelError(string.Empty, "Order not found");
            return RedirectToAction(
                nameof(Index),
                nameof(CartController).Replace("Controller", "")
            );
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, "Something went wrong");
            return RedirectToAction(
                nameof(Index),
                nameof(CartController).Replace("Controller", "")
            );
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateFromCart()
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
       
        try
        {
            var order = await _orderService.CreateFromCart(currentUserId);

            return RedirectToAction(nameof(Detail), new { id = order.Id });
        }
        catch (CartEmptyException)
        {
            ModelState.AddModelError(string.Empty, "Cart is empty");
            return RedirectToAction(
                nameof(Index),
                nameof(CartController).Replace("Controller", "")
            );
        }
        catch (NotFoundException)
        {
            ModelState.AddModelError(string.Empty, "Not found");
            return RedirectToAction(
                nameof(Index),
                nameof(CartController).Replace("Controller", "")
            );
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, "Something went wrong");
            return RedirectToAction(
                nameof(Index),
                nameof(CartController).Replace("Controller", "")
            );
        }
    }
}
