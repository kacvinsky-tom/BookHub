using AutoMapper;
using Core.DTO.Input.Author;
using Core.Services;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Admin.ViewModels.Author;
using WebMVC.ViewModels;

namespace WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AuthorController : Controller
{
    private readonly AuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorController(AuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        return View(
            _mapper.Map<PaginationViewModel<AuthorListViewModel>>(
                await _authorService.GetAllPaginated(page, pageSize)
            )
        );
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AuthorCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _authorService.Create(
                    new AuthorInputDto() { FirstName = model.FirstName, LastName = model.LastName }
                );
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }

            return RedirectToAction(
                nameof(Index),
                nameof(AuthorController).Replace("Controller", "")
            );
        }

        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var author = await _authorService.GetById(id);

        if (author == null)
        {
            return NotFound();
        }

        return View(_mapper.Map<AuthorEditViewModel>(author));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Author updated)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _authorService.Update(
                    new AuthorInputDto()
                    {
                        FirstName = updated.FirstName,
                        LastName = updated.LastName
                    },
                    updated.Id
                );
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(_mapper.Map<AuthorEditViewModel>(updated));
            }

            return RedirectToAction(
                nameof(Index),
                nameof(AuthorController).Replace("Controller", "")
            );
        }

        return View(_mapper.Map<AuthorEditViewModel>(updated));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _authorService.Delete(id);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, e.Message);
            return RedirectToAction(
                nameof(Index),
                nameof(AuthorController).Replace("Controller", "")
            );
        }

        TempData["Success"] = "Author deleted successfully";
        return RedirectToAction(nameof(Index), nameof(AuthorController).Replace("Controller", ""));
    }
}
