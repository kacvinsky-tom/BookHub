using Core.DTO.Input.LocalIdentityUser;
using Core.DTO.Input.User;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;

namespace Core.Services;

public class LocalIdentityUserService
{
    private readonly UserService _userService;
    private readonly UserManager<LocalIdentityUser> _userManager;
    private readonly SignInManager<LocalIdentityUser> _signInManager;

    public LocalIdentityUserService(
        UserService userService,
        UserManager<LocalIdentityUser> userManager,
        SignInManager<LocalIdentityUser> signInManager
    )
    {
        _userService = userService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> Create(
        LocalIdentityUserInputDto localIdentityUserInputDto,
        string defaultRole = "User",
        bool logIn = false
    )
    {
        var user = await _userService.Create(
            new UserInputDto()
            {
                Email = localIdentityUserInputDto.Email,
                Username = localIdentityUserInputDto.Username,
                FirstName = localIdentityUserInputDto.FirstName,
                LastName = localIdentityUserInputDto.LastName,
                PhoneNumber = localIdentityUserInputDto.PhoneNumber
            }
        );

        var identityUser = new LocalIdentityUser
        {
            UserName = localIdentityUserInputDto.Username,
            Email = localIdentityUserInputDto.Email,
            User = user
        };

        var result = await _userManager.CreateAsync(
            identityUser,
            localIdentityUserInputDto.Password
        );

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(identityUser, defaultRole);
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
}
