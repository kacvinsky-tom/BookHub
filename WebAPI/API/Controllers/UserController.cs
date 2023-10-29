using BookHub.API.DTO.Input;
using BookHub.API.InputType;
using BookHub.API.Mapper;
using BookHub.Services;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly UserService _userService;

    public UserController(UnitOfWork unitOfWork, UserService userService)
    {
        _unitOfWork = unitOfWork;
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var users = await _unitOfWork.Users.GetAll();
        
        return Ok(users.Select(UserMapper.MapList));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var user = await _unitOfWork.Users.GetByIdWithRelations(id);
        
        if (user == null)
        {
            return NotFound();
        }

        return Ok(UserMapper.MapDetail(user));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserInputDto userInputDto)
    {
        var user = _userService.Create(userInputDto);
        
        _unitOfWork.Users.Add(user);

        await _unitOfWork.Complete();

        return Ok(UserMapper.MapDetail(user));
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromBody] UserInputDto userInputDto, int id)
    {
        var user = await _unitOfWork.Users.GetById(id);
        
        if (user == null)
        {
            return NotFound();
        }

        _userService.Update(user, userInputDto);

        await _unitOfWork.Complete();

        return Ok(UserMapper.MapDetail(user));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _unitOfWork.Users.GetById(id);
        
        if (user == null)
        {
            return NotFound();
        }
        
        _unitOfWork.Users.Remove(user);

        await _unitOfWork.Complete();

        return Ok();
    }
}