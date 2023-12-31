using Core.DTO.Input.LocalIdentityUser;
using Core.DTO.Input.User;
using Core.Services;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Admin.ViewModels.User;

namespace WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly UserService _userService;
    private readonly LocalIdentityUserService _localIdentityUserService;

    public UserController(
        UserService userService,
        LocalIdentityUserService localIdentityUserService
    )
    {
        _userService = userService;
        _localIdentityUserService = localIdentityUserService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        return View(await _localIdentityUserService.GetAllPaginated(page, pageSize));
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

        var model = new UserEditViewModel()
        {
            Id = user.Id,
            Email = user.Email ?? "",
            Username = user.UserName ?? user.User.Username,
            FirstName = user.User.FirstName,
            LastName = user.User.LastName,
            PhoneNumber = user.User.PhoneNumber,
            Role = roles.FirstOrDefault() ?? "User",
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

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> ResetPassword(string id)
    {
        var user = await _localIdentityUserService.GetById(id);

        if (user == null)
        {
            return NotFound();
        }

        await _localIdentityUserService.ResetPassword(id);

        TempData["Success"] = "Password reset successfully!";
        return RedirectToAction(nameof(Index));
    }
}
