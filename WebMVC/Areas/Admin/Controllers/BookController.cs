using Core.DTO.Input.Book;
using Core.Services;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Admin.ViewModels.Book;

namespace WebMVC.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class BookController : Controller
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        return View(await _bookService.GetAllPaginated(page, pageSize));
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
}
