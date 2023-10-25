using BookHub.API.DTO.Input;
using BookHub.API.InputType;
using BookHub.API.Mapper;
using BookHub.DataAccessLayer;
using BookHub.DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;

    public UserController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
        var user = await _unitOfWork.Users.GetById(id);
        
        if (user == null)
        {
            return NotFound();
        }

        return Ok(UserMapper.MapDetail(user));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserInputDto userInputDto)
    {
        var passwordHasher = new PasswordHasher<User>();
        var user = new User
        {
            Username = userInputDto.Username,
            Email = userInputDto.Email,
            FirstName = userInputDto.FirstName,
            LastName = userInputDto.LastName,
            PhoneNumber = userInputDto.PhoneNumber,
            IsAdmin = userInputDto.IsAdmin,
        };
        user.Password = passwordHasher.HashPassword(user, userInputDto.Password);
        
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

        var passwordHasher = new PasswordHasher<User>();
        user.Username = userInputDto.Username;
        user.Email = userInputDto.Email;
        user.FirstName = userInputDto.FirstName;
        user.LastName = userInputDto.LastName;
        user.PhoneNumber = userInputDto.PhoneNumber;
        user.IsAdmin = userInputDto.IsAdmin;
        user.Password = passwordHasher.HashPassword(user, userInputDto.Password);

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