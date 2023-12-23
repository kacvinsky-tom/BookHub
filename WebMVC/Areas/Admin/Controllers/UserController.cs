﻿using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        // TODO: Make it, so this page returns LocalIdentityUser instead of User
        return View(await _userService.GetAllPaginated(page, pageSize));
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }

    public IActionResult ResetPassword()
    {
        return View();
    }
}
