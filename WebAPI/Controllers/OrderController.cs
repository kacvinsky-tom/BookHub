using AutoMapper;
using Core.DTO.Input.Order;
using Core.DTO.Output;
using Core.DTO.Output.Order;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

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
    public async Task<IActionResult> FetchPaginated(int page = 1, int pageSize = 10)
    {
        var orders = await _orderService.GetAllPaginated(page, pageSize);

        var paginatedOrders = _mapper.Map<PaginatedResult<OrderListOutputDto>>(orders);

        return Ok(paginatedOrders);
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
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] OrderUpdateInputDto orderUpdateInputDto
    )
    {
        try
        {
            var order = await _orderService.Update(orderUpdateInputDto, id);

            return Ok(_mapper.Map<OrderDetailOutputDto>(order));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _orderService.Delete(id);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
        catch (CannotDeleteException)
        {
            return Conflict("Cannot delete order because it has relations.");
        }
    }
}
