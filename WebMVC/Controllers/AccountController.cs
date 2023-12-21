using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.ViewModels;

namespace WebMVC.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<LocalIdentityUser> _userManager;
    private readonly SignInManager<LocalIdentityUser> _signInManager;

    public AccountController(
        UserManager<LocalIdentityUser> userManager,
        SignInManager<LocalIdentityUser> signInManager
    )
    {
        _userManager = userManager;
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
            var user = new LocalIdentityUser
            {
                UserName = model.Username,
                Email = model.Email,
                User = new User
                {
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email
                }
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _signInManager.SignInAsync(user, false);
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
