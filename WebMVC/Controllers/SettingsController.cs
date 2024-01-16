using System.Security.Claims;
using Core.DTO.Input.LocalIdentityUser;
using Core.DTO.Output;
using Core.Services;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Admin.ViewModels.User;
using WebMVC.ViewModels;

namespace WebMVC.Controllers;

[Authorize]
public class SettingsController : Controller
{
    private readonly UserService _userService;
    private readonly LocalIdentityUserService _localIdentityUserService;
    private readonly RoleManager<LocalIdentityRole> _roleManager;
    private readonly UserManager<LocalIdentityUser> _userManager;

    public SettingsController(
        UserService userService,
        LocalIdentityUserService localIdentityUserService,
        UserManager<LocalIdentityUser> userManager,
        RoleManager<LocalIdentityRole> roleManager
    )
    {
        _userService = userService;
        _localIdentityUserService = localIdentityUserService;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(SettingsChangePasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        if (User.Identity?.Name == null)
        {
            TempData["Error"] = "You are not logged in";
            return RedirectToAction("Login", "Account");
        }

        var result = await _localIdentityUserService.ChangePassword(
            User.Identity.Name,
            model.OldPassword,
            model.Password
        );

        if (result == IdentityResult.Success)
        {
            TempData["Success"] = "Password changed successfully";
            return RedirectToAction("Index");
        }
        else
        {
            TempData["Error"] =
                $"Password change failed: {string.Join(",", result.Errors.Select(e => e.Description).ToList())}";
            return RedirectToAction("ChangePassword");
        }
    }

    public async Task<IActionResult> ChangeInfo()
    {
        if (User.Identity?.Name == null)
        {
            return NotFound();
        }

        var user = await _localIdentityUserService.GetByUserName(User.Identity?.Name!);

        if (user == null)
        {
            return NotFound();
        }

        var model = new SettingsChangeInfoViewModel()
        {
            Email = user.Email ?? "",
            Username = user.UserName ?? user.User.Username,
            FirstName = user.User.FirstName,
            LastName = user.User.LastName,
            PhoneNumber = user.User.PhoneNumber
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeInfo(SettingsChangeInfoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (User.Identity?.Name == null)
        {
            return NotFound();
        }

        var user = await _localIdentityUserService.GetByUserName(User.Identity?.Name!);

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
                PhoneNumber = model.PhoneNumber
            },
            user.Id
        );

        return RedirectToAction(nameof(Index));
    }
}
