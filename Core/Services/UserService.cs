using AutoMapper;
using Core.DTO.Input.User;
using Core.DTO.Output;
using Core.Exception;
using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Services;

public class UserService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public UserService(UnitOfWork unitOfWork, IMemoryCache memoryCache, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _memoryCache = memoryCache;
        _mapper = mapper;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _unitOfWork.Users.GetAll();
    }

    public async Task<User?> GetById(int id)
    {
        if (_memoryCache.TryGetValue("user-" + id, out User? cachedUser))
        {
            return cachedUser;
        }

        var user = await _unitOfWork.Users.GetByIdWithRelations(id);

        if (user != null)
        {
            _memoryCache.Set("user-" + id, user);
        }

        return user;
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await _unitOfWork.Users.GetByUsername(username);
    }

    public async Task<User> Create(UserInputDto userInputDto)
    {
        var user = _mapper.Map<User>(userInputDto);

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

        _memoryCache.Set("user-" + userId, user);

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

        _memoryCache.Remove("user-" + userId);
    }

    public async Task<IEnumerable<SimpleListDto>> GetSimpleList()
    {
        var usersList = await _unitOfWork.Users.GetSimpleList();

        return _mapper.Map<IEnumerable<SimpleListDto>>(usersList);
    }
}
