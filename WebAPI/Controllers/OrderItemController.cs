using BookHub.DTO.Input.OrderItem;
using BookHub.Mapper;
using BookHub.Services;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderItemController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly OrderService _orderService;
    
    public OrderItemController(UnitOfWork unitOfWork, OrderService orderService)
    {
        _unitOfWork = unitOfWork;
        _orderService = orderService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var orderItems = await _unitOfWork.OrderItems.GetAllWithRelations();
        
        return Ok(orderItems.Select(OrderItemMapper.MapList));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var orderItem = await _unitOfWork.OrderItems.GetByIdWithRelations(id);
        
        if (orderItem == null)
        {
            return NotFound();
        }

        return Ok(OrderItemMapper.MapDetail(orderItem));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderItemCreateInputDto orderCreateInputInputDto)
    {
        try
        {
            var orderItem = await _orderService.CreateItemInWishlist(orderCreateInputInputDto);
            _unitOfWork.OrderItems.Add(orderItem);
            await _unitOfWork.Complete();
            return Ok(OrderItemMapper.MapCreateDetail(orderItem));
        }
        catch (EntityNotFoundException<User> e)
        {
            return NotFound(e.Message);
        }
    }
}