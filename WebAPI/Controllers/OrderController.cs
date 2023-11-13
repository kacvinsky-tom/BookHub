using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.Order;
using WebAPI.DTO.Output.Order;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(OrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var orders = await _orderService.GetAll();
        
        return Ok(orders.Select(_mapper.Map<OrderListOutputDto>));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var order = await _orderService.GetById(id);
        
        if (order == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<OrderDetailOutputDto>(order));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderCreateInputDto orderCreateInputDto)
    {
        try
        {
            var order = await _orderService.Create(orderCreateInputDto);

            return Ok(_mapper.Map<OrderDetailOutputDto>(order));
        }
        catch (EntityNotFoundException<User> e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrderUpdateInputDto orderUpdateInputDto)
    {
        var order = await  _orderService.Update(orderUpdateInputDto, id);

        return Ok(_mapper.Map<OrderDetailOutputDto>(order));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _orderService.Delete(id);

        return Ok();
    }
}