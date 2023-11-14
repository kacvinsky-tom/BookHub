using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
using WebAPI.DTO.Input.User;
using WebAPI.Exception;

namespace WebAPI.Services;

public class UserService
{
    private readonly UnitOfWork _unitOfWork;

    public UserService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _unitOfWork.Users.GetAll();
    }
    
    public async Task<User?> GetById(int id)
    {
        return await _unitOfWork.Users.GetByIdWithRelations(id);
    }

    public async Task<User> Create(UserInputDto userInputDto)
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

        return user;
    }

    public async Task<User> Update(UserInputDto userInputDto, int userId)
    {
        var user = await _unitOfWork.Users.GetById(userId);
        
        if (user == null)
        {
            throw new EntityNotFoundException<User>(userId);
        }
        
        var passwordHasher = new PasswordHasher<User>();

        user.Username = userInputDto.Username;
        user.Email = userInputDto.Email;
        user.FirstName = userInputDto.FirstName;
        user.LastName = userInputDto.LastName;
        user.PhoneNumber = userInputDto.PhoneNumber;
        user.IsAdmin = userInputDto.IsAdmin;

        // This should be moved away to separate endpoint/flow of user actions in the future
        user.Password = passwordHasher.HashPassword(user, userInputDto.Password);

        await _unitOfWork.Complete();
        
        return user;
    }
    
    public async Task Delete(int userId)
    {
        var user = await _unitOfWork.Users.GetById(userId);

        if (user == null)
        {
            throw new EntityNotFoundException<User>(userId);
        }

        _unitOfWork.Users.Remove(user);

        await _unitOfWork.Complete();
    }
}