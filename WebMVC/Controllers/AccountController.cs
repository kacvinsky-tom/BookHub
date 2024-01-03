using Core.DTO.Input.LocalIdentityUser;
using Core.Services;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.ViewModels;

namespace WebMVC.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<LocalIdentityUser> _signInManager;
    private readonly LocalIdentityUserService _localIdentityUserService;

    public AccountController(
        LocalIdentityUserService localIdentityUserService,
        SignInManager<LocalIdentityUser> signInManager
    )
    {
        _localIdentityUserService = localIdentityUserService;
        _signInManager = signInManager;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _localIdentityUserService.Create(
                new LocalIdentityUserInputDto()
                {
                    Email = model.Email,
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Password = model.Password,
                    Role = "User"
                },
                true
            );

            if (result.Succeeded)
            {
                return RedirectToAction(
                    nameof(Login),
                    nameof(AccountController).Replace("Controller", "")
                );
            }
            ModelState.AddModelError(
                string.Empty,
                "Registration failed: "
                    + string.Join(", ", result.Errors.Select(e => e.Description))
            );
        }

        return View(model);
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false
            );

            if (result.Succeeded)
            {
                return RedirectToAction(
                    nameof(LoginSuccess),
                    nameof(AccountController).Replace("Controller", "")
                );
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(
            nameof(HomeController.Index),
            nameof(HomeController).Replace("Controller", "")
        );
    }

    public IActionResult LoginSuccess()
    {
        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
