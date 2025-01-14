﻿using AutoMapper;
using Core.DTO.Input.Publisher;
using Core.Services;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Admin.ViewModels.Publisher;
using WebMVC.ViewModels;

namespace WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class PublisherController : Controller
{
    private readonly PublisherService _publisherService;
    private readonly IMapper _mapper;

    public PublisherController(PublisherService publisherService, IMapper mapper)
    {
        _publisherService = publisherService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        return View(
            _mapper.Map<PaginationViewModel<PublisherListViewModel>>(
                await _publisherService.GetAllPaginated(page, pageSize)
            )
        );
    }

    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> Edit(int id)
    {
        var publisher = await _publisherService.GetById(id);

        if (publisher == null)
        {
            return NotFound();
        }

        return View(_mapper.Map<PublisherEditViewModel>(publisher));
    }

    [HttpPost]
    public async Task<IActionResult> Create(PublisherCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _publisherService.Create(
                    new PublisherInputDto()
                    {
                        Name = model.Name,
                        State = model.State,
                        Email = model.Email
                    }
                );
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(model);
            }

            return RedirectToAction(
                nameof(Index),
                nameof(PublisherController).Replace("Controller", "")
            );
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Publisher updated)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _publisherService.Update(
                    new PublisherInputDto()
                    {
                        Name = updated.Name,
                        State = updated.State,
                        Email = updated.Email
                    },
                    updated.Id
                );
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(_mapper.Map<PublisherEditViewModel>(updated));
            }

            return RedirectToAction(
                nameof(Index),
                nameof(PublisherController).Replace("Controller", "")
            );
        }

        return View(_mapper.Map<PublisherEditViewModel>(updated));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _publisherService.Delete(id);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, e.Message);
        }

        TempData["Success"] = "Publisher deleted successfully";
        return RedirectToAction(
            nameof(Index),
            nameof(PublisherController).Replace("Controller", "")
        );
    }
}
