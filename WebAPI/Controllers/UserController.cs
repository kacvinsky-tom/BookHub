using AutoMapper;
using Core.DTO.Input.User;
using Core.DTO.Output.Order;
using Core.DTO.Output.User;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;
    private readonly OrderService _orderService;

    public UserController(UserService userService, IMapper mapper, OrderService orderService)
    {
        _userService = userService;
        _mapper = mapper;
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var users = await _userService.GetAll();

        return Ok(users.Select(_mapper.Map<UserListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var user = await _userService.GetById(id);

        if (user == null)
        {
            return NotFound();
        }

        var userDetailDto = _mapper.Map<UserDetailOutputDto>(user);

        return Ok(userDetailDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserInputDto userInputDto)
    {
        var user = await _userService.Create(userInputDto);

        return Ok(_mapper.Map<UserDetailOutputDto>(user));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromBody] UserInputDto userInputDto, int id)
    {
        try
        {
            var user = await _userService.Update(userInputDto, id);

            var userDetailDto = _mapper.Map<UserDetailOutputDto>(user);

            return Ok(userDetailDto);
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
            await _userService.Delete(id);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }

    [HttpGet("{id:int}/orders")]
    public async Task<IActionResult> FetchOrders(int id)
    {
        var orders = await _orderService.GetAllByUserId(id);

        return Ok(orders.Select(_mapper.Map<OrderListOutputDto>));
    }
}
