using Core.DTO.Input.User;
using Core.Exception;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Core.Services;

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

    public async Task<PaginationObject<User>> GetAllPaginated(int page, int pageSize)
    {
        return await _unitOfWork.Users.GetPaginated(page, pageSize);
    }

    public async Task<User?> GetById(int id)
    {
        return await _unitOfWork.Users.GetByIdWithRelations(id);
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await _unitOfWork.Users.GetByUsername(username);
    }

    public async Task<User> Create(UserInputDto userInputDto)
    {
        var user = new User
        {
            Username = userInputDto.Username,
            Email = userInputDto.Email,
            FirstName = userInputDto.FirstName,
            LastName = userInputDto.LastName,
            PhoneNumber = userInputDto.PhoneNumber,
        };

        await _unitOfWork.Users.Add(user);

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

        user.Username = userInputDto.Username;
        user.Email = userInputDto.Email;
        user.FirstName = userInputDto.FirstName;
        user.LastName = userInputDto.LastName;
        user.PhoneNumber = userInputDto.PhoneNumber;

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
