using AutoMapper;
using Core.DTO.Input.Review;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Shop.ViewModel.Book;
using WebMVC.Areas.Shop.ViewModel.Review;

namespace WebMVC.Areas.Shop.Controllers;

[Area("Shop")]
public class BookController : Controller
{
    private readonly BookService _bookService;
    private readonly ReviewService _reviewService;
    private readonly UserService _userService;
    private readonly IMapper _mapper;

    public BookController(
        BookService bookService,
        IMapper mapper,
        ReviewService reviewService,
        UserService userService
    )
    {
        _bookService = bookService;
        _mapper = mapper;
        _reviewService = reviewService;
        _userService = userService;
    }

    public async Task<IActionResult> Detail(int id)
    {
        var book = await _bookService.GetById(id);

        if (book == null)
        {
            return NotFound();
        }

        return View(_mapper.Map<BookDetailViewModel>(book));
    }

    [HttpPost("/Shop/Book/AddReview")]
    public async Task<IActionResult> AddReview(ReviewCreateViewModel reviewCreateViewModel)
    {
        var book = await _bookService.GetById(reviewCreateViewModel.BookId);

        if (book == null)
        {
            return NotFound($"Book with id {reviewCreateViewModel.BookId} not found");
        }

        var review = _mapper.Map<ReviewCreateInputDto>(reviewCreateViewModel);

        if (User.Identity?.Name == null)
        {
            return NotFound($"Invalid user");
        }

        var user = await _userService.GetByUsername(User.Identity.Name);

        if (user == null)
        {
            return NotFound($"Invalid user");
        }

        review.UserId = user.Id;

        await _reviewService.Create(review);

        return RedirectToAction("Detail", new { id = reviewCreateViewModel.BookId });
    }

    [HttpPost("Shop/Book/DeleteReview/{id:int}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
        var review = await _reviewService.GetById(id);

        if (review == null)
        {
            return NotFound();
        }

        if (!User.IsInRole("Admin") && review.User.Username != User.Identity?.Name)
        {
            return Forbid();
        }

        await _reviewService.Delete(id);

        return RedirectToAction("Detail", new { id = review.BookId });
    }
}
