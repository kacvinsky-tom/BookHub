using AutoMapper;
using Core.DTO.Input.User;
using Core.DTO.Output.User;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;

    public UserController(UserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
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
}
