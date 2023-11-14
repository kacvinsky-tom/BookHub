using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.OrderItem;
using WebAPI.DTO.Output.OrderItem;
using WebAPI.Exception;
using WebAPI.Extensions;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderItemController : ControllerBase
{
    private readonly OrderService _orderService;
    private readonly IMapper _mapper;

    public OrderItemController(OrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var orderItems = await _orderService.GetAllOrderItems();
        
        return Ok(orderItems.Select(_mapper.Map<OrderItemListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var orderItem = await _orderService.GetOrderItemById(id);
        
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
            var orderItem = await _orderService.CreateOrderItem(orderCreateInputInputDto);

            return Ok(_mapper.Map<OrderItemDetailOutputDto>(orderItem));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}