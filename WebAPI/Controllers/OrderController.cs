using AutoMapper;
using DataAccessLayer;
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
    private readonly UnitOfWork _unitOfWork;
    private readonly OrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(UnitOfWork unitOfWork, OrderService orderService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _orderService = orderService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var orders = await _unitOfWork.Orders.GetAllWithRelations();
        
        return Ok(orders.Select(_mapper.Map<OrderListOutputDto>));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdWithRelations(id);
        
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
            _unitOfWork.Orders.Add(order);
            await _unitOfWork.Complete();
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
        var order = await _unitOfWork.Orders.GetByIdWithRelations(id);
        
        if (order == null)
        {
            return NotFound();
        }
        
        _orderService.Update(orderUpdateInputDto, order);
        await _unitOfWork.Complete();
        return Ok(_mapper.Map<OrderDetailOutputDto>(order));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var order = await _unitOfWork.Orders.GetById(id);
        
        if (order == null)
        {
            return NotFound();
        }

        _unitOfWork.Orders.Remove(order);
        
        await _unitOfWork.Complete();

        return Ok();
    }
}