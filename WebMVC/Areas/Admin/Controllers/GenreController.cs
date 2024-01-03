using Core.DTO.Input.Genre;
using Core.Services;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Admin.ViewModels.Genre;

namespace WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class GenreController : Controller
{
    private readonly GenreService _genreService;

    public GenreController(GenreService genreService)
    {
        _genreService = genreService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        return View(await _genreService.GetAllPaginated(page, pageSize));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(GenreCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _genreService.Create(new GenreInputDto() { Name = model.Name });
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }

            return RedirectToAction(
                nameof(Index),
                nameof(GenreController).Replace("Controller", "")
            );
        }

        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var genre = await _genreService.GetById(id);

        if (genre == null)
        {
            return NotFound();
        }

        return View(genre);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Genre updated)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _genreService.Update(new GenreInputDto() { Name = updated.Name }, updated.Id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(updated);
            }

            return RedirectToAction(
                nameof(Index),
                nameof(GenreController).Replace("Controller", "")
            );
        }

        return View(updated);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _genreService.Delete(id);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, e.Message);
        }

        TempData["Success"] = "Genre deleted successfully";
        return RedirectToAction(nameof(Index), nameof(GenreController).Replace("Controller", ""));
    }
}
