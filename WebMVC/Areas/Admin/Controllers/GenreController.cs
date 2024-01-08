using AutoMapper;
using Core.DTO.Input.Genre;
using Core.Services;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Admin.ViewModels.Genre;
using WebMVC.ViewModels;

namespace WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class GenreController : Controller
{
    private readonly GenreService _genreService;
    private readonly IMapper _mapper;

    public GenreController(GenreService genreService, IMapper mapper)
    {
        _genreService = genreService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        return View(_mapper.Map<PaginationViewModel<GenreListViewModel>>(await _genreService.GetAllPaginated(page, pageSize)));
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

        return View(_mapper.Map<GenreEditViewModel>(genre));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Genre updated)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _genreService.Update(new GenreInputDto { Name = updated.Name }, updated.Id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(_mapper.Map<GenreEditViewModel>(updated));
            }

            return RedirectToAction(
                nameof(Index),
                nameof(GenreController).Replace("Controller", "")
            );
        }

        return View(_mapper.Map<GenreEditViewModel>(updated));
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
