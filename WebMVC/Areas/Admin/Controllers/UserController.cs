using AutoMapper;
using Core.DTO.Input.LocalIdentityUser;
using Core.DTO.Output;
using Core.Exception;
using Core.Services;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Admin.ViewModels.User;
using WebMVC.ViewModels;

namespace WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly LocalIdentityUserService _localIdentityUserService;
    private readonly RoleManager<LocalIdentityRole> _roleManager;
    private readonly IMapper _mapper;

    public UserController(
        LocalIdentityUserService localIdentityUserService,
        RoleManager<LocalIdentityRole> roleManager,
        IMapper mapper
    )
    {
        _localIdentityUserService = localIdentityUserService;
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        return View(
            _mapper.Map<PaginationViewModel<UserListViewModel>>(
                await _localIdentityUserService.GetAllPaginated(page, pageSize)
            )
        );
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await _localIdentityUserService.Create(
            new LocalIdentityUserInputDto()
            {
                Email = model.Email,
                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                Role = model.Role
            }
        );

        if (result.Succeeded)
        {
            return RedirectToAction(nameof(Index));
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var user = await _localIdentityUserService.GetById(id);

        if (user == null)
        {
            return NotFound();
        }

        var roles = await _localIdentityUserService.GetRolesOfUser(user);
        var availableRoles = _roleManager
            .Roles.Select(r => new SimpleListDto() { Id = r.Name ?? "", Value = r.Name ?? "" })
            .ToList();

        var model = new UserEditViewModel()
        {
            Id = user.Id,
            Email = user.Email ?? "",
            Username = user.UserName ?? user.User.Username,
            FirstName = user.User.FirstName,
            LastName = user.User.LastName,
            PhoneNumber = user.User.PhoneNumber,
            Role = roles.FirstOrDefault() ?? "User",
            AvailableRoles = availableRoles
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _localIdentityUserService.GetById(model.Id);

        if (user == null)
        {
            return NotFound();
        }

        await _localIdentityUserService.Update(
            new LocalIdentityUserInputDto()
            {
                Email = model.Email,
                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Role = model.Role
            },
            model.Id
        );

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _localIdentityUserService.GetById(id);

        if (user == null)
        {
            return NotFound();
        }

        await _localIdentityUserService.Delete(id);

        TempData["Success"] = "User deleted successfully!";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> ResetPassword(string id)
    {
        var user = await _localIdentityUserService.GetById(id);

        if (user == null)
        {
            return NotFound();
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ResetPassword(string id, UserResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _localIdentityUserService.SetPassword(id, model.Password);
        }
        catch (EntityNotFoundException<LocalIdentityUser, string>)
        {
            return NotFound();
        }

        TempData["Success"] = "Password reset successfully!";
        return RedirectToAction(nameof(Index));
    }
}
