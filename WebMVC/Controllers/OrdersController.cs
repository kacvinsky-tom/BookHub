using System.Security.Claims;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebMVC.ViewModels;

namespace WebMVC.Controllers;

public class OrdersController : Controller
{
    private readonly OrderService _orderService;
    private readonly UserService _userService;

    public OrdersController(OrderService orderService, UserService userService)
    {
        _orderService = orderService;
        _userService = userService;
    }

    public async Task<IActionResult> OrdersHistory()
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

    public async Task<IActionResult> OrderDetail(int id)
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
}
