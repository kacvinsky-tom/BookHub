using AutoMapper;
using Core.DTO.Input.Review;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Shop.ViewModel.Book;
using WebMVC.Areas.Shop.ViewModel.Review;
using WebMVC.ViewModels;

namespace WebMVC.Areas.Shop.Controllers;

[Area("Shop")]
public class BookController : Controller
{
    private readonly BookService _bookService;
    private readonly ReviewService _reviewService;
    private readonly UserService _userService;
    private readonly GenreService _genreService;
    private readonly AuthorService _authorService;
    private readonly IMapper _mapper;

    public BookController(
        BookService bookService,
        IMapper mapper,
        ReviewService reviewService,
        UserService userService,
        GenreService genreService,
        AuthorService authorService
    )
    {
        _bookService = bookService;
        _mapper = mapper;
        _reviewService = reviewService;
        _userService = userService;
        _genreService = genreService;
        _authorService = authorService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 12)
    {
        return View(
            _mapper.Map<PaginationViewModel<BookFullListViewModel>>(
                await _bookService.GetAllPaginated(page, pageSize)
            )
        );
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

    [HttpPost("/Shop/Book/DeleteReview/{id:int}")]
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

    [HttpGet("/Shop/Book/ByGenre/{genreId:int}")]
    public async Task<IActionResult> ByGenre(int genreId, int page = 1, int pageSize = 12)
    {
        var genre = await _genreService.GetById(genreId);

        if (genre == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<PaginatedBooksByGenreViewModel>(
            await _bookService.GetByGenrePaginated(genreId, pageSize, page)
        );

        model.GenreId = genreId;
        model.GenreDisplayName = genre.Name;

        return View(model);
    }

    [HttpGet("/Shop/Book/ByAuthor/{authorId:int}")]
    public async Task<IActionResult> ByAuthor(int authorId, int page = 1, int pageSize = 12)
    {
        var author = await _authorService.GetById(authorId);

        if (author == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<PaginatedBooksByAuthorViewModel>(
            await _bookService.GetByAuthorPaginated(authorId, pageSize, page)
        );

        model.AuthorId = authorId;
        model.AuthorDisplayName = author.FirstName + " " + author.LastName;

        return View(model);
    }
}
