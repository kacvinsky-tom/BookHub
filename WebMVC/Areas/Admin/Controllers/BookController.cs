﻿using AutoMapper;
using Core.DTO.Input.Book;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Admin.ViewModels.Book;
using WebMVC.ViewModels;
using BookListViewModel = WebMVC.Areas.Admin.ViewModels.Book.BookListViewModel;

namespace WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class BookController : Controller
{
    private readonly BookService _bookService;
    private readonly GenreService _genreService;
    private readonly PublisherService _publisherService;
    private readonly AuthorService _authorService;
    private readonly IMapper _mapper;

    public BookController(
        BookService bookService,
        GenreService genreService,
        PublisherService publisherService,
        AuthorService authorService,
        IMapper mapper
    )
    {
        _bookService = bookService;
        _genreService = genreService;
        _publisherService = publisherService;
        _authorService = authorService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        return View(
            _mapper.Map<PaginationViewModel<BookListViewModel>>(
                await _bookService.GetAllPaginated(page, pageSize)
            )
        );
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _bookService.Create(
                    new BookCreateInputDto()
                    {
                        Title = model.Title,
                        ISBN = model.ISBN,
                        Description = model.Description,
                        Price = model.Price,
                        PublisherId = model.PublisherId,
                        Image = model.Image,
                        Quantity = model.Quantity,
                        ReleaseYear = model.ReleaseYear,
                        AuthorIds = model.AuthorIds,
                        GenreIds = model.GenreIds,
                        PrimaryGenreId = model.PrimaryGenreId,
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
                nameof(BookController).Replace("Controller", "")
            );
        }

        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var book = await _bookService.GetById(id);

        if (book == null)
        {
            return NotFound();
        }

        return View(
            new BookUpdateViewModel()
            {
                Title = book.Title,
                ISBN = book.ISBN,
                Description = book.Description,
                Price = book.Price,
                PublisherId = book.PublisherId,
                Image = book.Image,
                Quantity = book.Quantity,
                ReleaseYear = book.ReleaseYear,
                AuthorIds = book.Authors.Select(a => a.Id).ToList(),
                GenreIds = book.Genres.Select(g => g.Id).ToList(),
                PrimaryGenreId = book.BookGenres.First(bg => bg.IsPrimary).Genre.Id,
                Genres = await _genreService.GetSimpleList(),
                Authors = await _authorService.GetSimpleList(),
                Publishers = await _publisherService.GetSimpleList(),
            }
        );
    }

    [HttpPost]
    public async Task<IActionResult> Edit(BookUpdateViewModel updated)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _bookService.Update(
                    new BookCreateInputDto()
                    {
                        Title = updated.Title,
                        ISBN = updated.ISBN,
                        Description = updated.Description,
                        Price = updated.Price,
                        PublisherId = updated.PublisherId,
                        Image = updated.Image,
                        Quantity = updated.Quantity,
                        ReleaseYear = updated.ReleaseYear,
                        AuthorIds = updated.AuthorIds,
                        GenreIds = updated.GenreIds,
                        PrimaryGenreId = updated.PrimaryGenreId
                    },
                    updated.Id
                );
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(updated);
            }

            return RedirectToAction(
                nameof(Index),
                nameof(BookController).Replace("Controller", "")
            );
        }

        return View(updated);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _bookService.Delete(id);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, e.Message);
            return RedirectToAction(
                nameof(Index),
                nameof(BookController).Replace("Controller", "")
            );
        }

        TempData["Success"] = "Book deleted successfully";
        return RedirectToAction(nameof(Index), nameof(BookController).Replace("Controller", ""));
    }
}
