using AutoMapper;
using Core.DTO.Input.LocalIdentityUser;
using Core.DTO.Input.User;
using Core.Exception;
using Core.Helpers;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Core.Services;

public class LocalIdentityUserService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly UserService _userService;
    private readonly UserManager<LocalIdentityUser> _userManager;
    private readonly SignInManager<LocalIdentityUser> _signInManager;
    private readonly IMapper _mapper;

    public LocalIdentityUserService(
        UserService userService,
        UserManager<LocalIdentityUser> userManager,
        SignInManager<LocalIdentityUser> signInManager,
        UnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _userService = userService;
        _userManager = userManager;
        _signInManager = signInManager;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IdentityResult> Create(
        LocalIdentityUserInputDto localIdentityUserInputDto,
        bool logIn = false
    )
    {
        var userInputDto = _mapper.Map<UserInputDto>(localIdentityUserInputDto);

        var user = await _userService.Create(userInputDto);

        var identityUser = _mapper.Map<LocalIdentityUser>(localIdentityUserInputDto);
        identityUser.User = user;

        var result = await _userManager.CreateAsync(
            identityUser,
            localIdentityUserInputDto.Password
        );

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(identityUser, localIdentityUserInputDto.Role);
            if (logIn)
            {
                await _signInManager.SignInAsync(identityUser, false);
            }
        }
        else
        {
            await _userService.Delete(user.Id);
        }

        return result;
    }

    public async Task<IdentityResult> Update(
        LocalIdentityUserInputDto localIdentityUserInputDto,
        string localIdentityUserId
    )
    {
        var user = await _unitOfWork.LocalIdentityUsers.GetById(localIdentityUserId);

        if (user == null)
        {
            throw new EntityNotFoundException<LocalIdentityUser, string>(localIdentityUserId);
        }

        user.UserName = localIdentityUserInputDto.Username;
        user.User.Username = localIdentityUserInputDto.Username;
        user.PhoneNumber = localIdentityUserInputDto.PhoneNumber;
        user.Email = localIdentityUserInputDto.Email;
        user.User.FirstName = localIdentityUserInputDto.FirstName;
        user.User.LastName = localIdentityUserInputDto.LastName;
        user.User.PhoneNumber = localIdentityUserInputDto.PhoneNumber;

        var userRoles = await _userManager.GetRolesAsync(user);

        if (!userRoles.Contains(localIdentityUserInputDto.Role))
        {
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRoleAsync(user, localIdentityUserInputDto.Role);
        }

        var result = await _userManager.UpdateAsync(user);

        return result;
    }

    public async Task SetPassword(string localIdentityUserId, string password)
    {
        var user = await _unitOfWork.LocalIdentityUsers.GetById(localIdentityUserId);

        if (user == null)
        {
            throw new EntityNotFoundException<LocalIdentityUser, string>(localIdentityUserId);
        }

        await _userManager.RemovePasswordAsync(user);
        await _userManager.AddPasswordAsync(user, password);
    }

    public async Task<LocalIdentityUser?> GetById(string id)
    {
        return await _unitOfWork.LocalIdentityUsers.GetById(id);
    }

    public async Task<IList<string>> GetRolesOfUser(LocalIdentityUser u)
    {
        return await _userManager.GetRolesAsync(u);
    }

    public async Task<PaginationObject<LocalIdentityUser>> GetAllPaginated(int page, int pageSize)
    {
        var ordering = new Ordering<LocalIdentityUser>
        {
            Expression = u => u.UserName ?? u.UserId.ToString()
        };

        return await _unitOfWork.LocalIdentityUsers.GetAllPaginated(
            page,
            pageSize,
            order: new[] { ordering }
        );
    }

    public async Task<IdentityResult> Delete(string id)
    {
        var user = await _unitOfWork.LocalIdentityUsers.GetById(id);

        if (user == null)
        {
            throw new EntityNotFoundException<LocalIdentityUser, string>(id);
        }

        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded)
        {
            await _userService.Delete(user.UserId);
        }

        return result;
    }
}
