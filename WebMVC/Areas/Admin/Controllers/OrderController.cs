using AutoMapper;
using Core.DTO.Input.Order;
using Core.DTO.Input.OrderItem;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Admin.ViewModels.Order;
using WebMVC.ViewModels;

namespace WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class OrderController : Controller
{
    private readonly OrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(OrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        return View(
            _mapper.Map<PaginationViewModel<OrderListViewModel>>(
                await _orderService.GetAllPaginated(page, pageSize)
            )
        );
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrderCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await _orderService.Create(
            new OrderCreateInputDto() { UserId = model.UserId, Status = model.Status }
        );

        TempData["Success"] = "Order created successfully";
        return RedirectToAction("Edit", new { id = result.Id });
    }

    public async Task<IActionResult> Edit(int id)
    {
        var order = await _orderService.GetById(id);

        if (order == null)
        {
            return NotFound();
        }

        return View(
            new OrderEditViewModel()
            {
                Id = order.Id,
                UserId = order.UserId,
                Status = order.Status,
                OrderItems = order.OrderItems.ToList(),
            }
        );
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, OrderEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _orderService.Update(new OrderUpdateInputDto() { Status = model.Status }, id);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, e.Message);
        }

        TempData["Success"] = "Order updated successfully";
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _orderService.Delete(id);

        TempData["Success"] = "Order deleted successfully";
        return RedirectToAction("Index");
    }

    [HttpGet("Admin/Order/{id}/AddOrderItem/")]
    public async Task<IActionResult> AddOrderItem(int id)
    {
        var order = await _orderService.GetById(id);

        if (order == null)
        {
            return NotFound();
        }

        return View(new OrderItemCreateViewModel() { OrderId = order.Id, });
    }

    [HttpPost("Admin/Order/{id}/AddOrderItem/")]
    public async Task<IActionResult> AddOrderItem(OrderItemCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _orderService.CreateOrderItem(
                new OrderItemCreateInputDto()
                {
                    OrderId = model.OrderId,
                    BookId = model.BookId,
                    Quantity = model.Quantity,
                }
            );
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, e.Message);
        }

        TempData["Success"] = "Order item added successfully";
        return RedirectToAction("Edit", new { id = model.OrderId });
    }

    [HttpGet("Admin/Order/EditOrderItem/{id}/")]
    public async Task<IActionResult> EditOrderItem(int id)
    {
        var orderItem = await _orderService.GetOrderItemById(id);

        if (orderItem == null)
        {
            return NotFound();
        }

        return View(
            new OrderItemEditViewModel()
            {
                Id = orderItem.Id,
                OrderId = orderItem.OrderId,
                BookId = orderItem.BookId,
                Quantity = orderItem.Quantity,
            }
        );
    }

    [HttpPost("Admin/Order/EditOrderItem/{id}/")]
    public async Task<IActionResult> EditOrderItem(int id, OrderItemEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            if (model.BookId == null)
            {
                throw new Exception("Book is required");
            }

            await _orderService.UpdateOrderItem(
                new OrderItemUpdateInputDto()
                {
                    Quantity = model.Quantity,
                    BookId = model.BookId.Value
                },
                id
            );
            TempData["Success"] = "Order item updated successfully";
            return RedirectToAction("Edit", new { id = model.OrderId });
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, e.Message);
        }

        return View(model);
    }

    [HttpPost("Admin/Order/DeleteOrderItem/{id}/")]
    public async Task<IActionResult> DeleteOrderItem(int id)
    {
        var orderItem = await _orderService.GetOrderItemById(id);

        if (orderItem == null)
        {
            return NotFound();
        }

        await _orderService.DeleteOrderItem(id);

        TempData["Success"] = "Order item deleted successfully";
        return RedirectToAction("Edit", new { id = orderItem.OrderId });
    }
}
