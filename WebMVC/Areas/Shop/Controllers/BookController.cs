using AutoMapper;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Areas.Shop.ViewModel.Book;

namespace WebMVC.Areas.Shop.Controllers;

[Area("Shop")]
public class BookController : Controller
{
    private readonly BookService _bookService;
    private readonly IMapper _mapper;

    public BookController(BookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
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
}