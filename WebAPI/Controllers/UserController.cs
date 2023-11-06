using AutoMapper;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.User;
using WebAPI.DTO.Output.User;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly UserService _userService;
    private readonly IMapper _mapper;

    public UserController(UnitOfWork unitOfWork, UserService userService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var users = await _unitOfWork.Users.GetAll();
        
        return Ok(users.Select(_mapper.Map<UserListOutputDto>));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var user = await _unitOfWork.Users.GetByIdWithRelations(id);
        
        if (user == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<UserDetailOutputDto>(user));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserInputDto userInputDto)
    {
        var user = _userService.Create(userInputDto);
        
        _unitOfWork.Users.Add(user);

        await _unitOfWork.Complete();

        return Ok(_mapper.Map<UserDetailOutputDto>(user));
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

        return Ok(_mapper.Map<UserDetailOutputDto>(user));
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