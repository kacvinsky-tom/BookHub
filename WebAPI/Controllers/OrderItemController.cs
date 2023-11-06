using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.OrderItem;
using WebAPI.DTO.Output.OrderItem;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderItemController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly OrderService _orderService;
    private readonly IMapper _mapper;

    public OrderItemController(UnitOfWork unitOfWork, OrderService orderService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _orderService = orderService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var orderItems = await _unitOfWork.OrderItems.GetAllWithRelations();
        
        return Ok(orderItems.Select(_mapper.Map<OrderItemListOutputDto>));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var orderItem = await _unitOfWork.OrderItems.GetByIdWithRelations(id);
        
        if (orderItem == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<OrderItemDetailOutputDto>(orderItem));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderItemCreateInputDto orderCreateInputInputDto)
    {
        try
        {
            var orderItem = await _orderService.CreateItemInWishlist(orderCreateInputInputDto);
            _unitOfWork.OrderItems.Add(orderItem);
            await _unitOfWork.Complete();
            return Ok(_mapper.Map<OrderItemDetailOutputDto>(orderItem));
        }
        catch (EntityNotFoundException<User> e)
        {
            return NotFound(e.Message);
        }
    }
}