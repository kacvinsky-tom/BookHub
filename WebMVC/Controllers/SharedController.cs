using AutoMapper;
using Core.DTO.Input.Search;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebMVC.ViewModels;

namespace WebMVC.Controllers;

public class SharedController : Controller
{
    private readonly AuthorService _authorService;
    private readonly BookService _bookService;
    private readonly GenreService _genreService;
    private readonly IMapper _mapper;
    private const int PrimarySearchObjectsDefaultSize = 6;
    private const int SecondarySearchObjectsDefaultSize = 6;

    public SharedController(
        AuthorService authorService,
        BookService bookService,
        GenreService genreService,
        IMapper mapper
    )
    {
        _authorService = authorService;
        _bookService = bookService;
        _genreService = genreService;
        _mapper = mapper;
    }

    [HttpGet("search")]
    public async Task<IActionResult> GlobalSearch(
        SearchViewInputModel searchInputModel,
        int page = 1,
        int pageSize = PrimarySearchObjectsDefaultSize
    )
    {
        var searchCriteria = new SearchQueryInputDto { Query = searchInputModel.Query.Trim() };

        var authors = await _authorService.Search(
            searchCriteria,
            1,
            SecondarySearchObjectsDefaultSize
        );
        var genres = await _genreService.Search(
            searchCriteria,
            1,
            SecondarySearchObjectsDefaultSize
        );
        var books = await _bookService.Search(searchCriteria, page, pageSize);

        var viewModel = new SearchListViewModel
        {
            Authors = authors.Items.Select(_mapper.Map<AuthorListViewModel>),
            Genres = genres.Items.Select(_mapper.Map<GenreListViewModel>),
            Books = books.Items.Select(_mapper.Map<BookListViewModel>),
            CurrentPage = page,
            TotalPages = books.TotalPages,
            Query = searchInputModel.Query
        };

        return View("SearchResult", viewModel);
    }
}
