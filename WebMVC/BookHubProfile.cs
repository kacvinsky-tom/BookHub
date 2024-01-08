using AutoMapper;
using Core.DTO.Output.Author;
using Core.DTO.Output.Book;
using Core.DTO.Output.Genre;
using DataAccessLayer.Entity;
using WebMVC.Areas.Shop.ViewModel.Book;
using WebMVC.Areas.Shop.ViewModel.CartItem;

namespace WebMVC;

public class BookHubProfile : Profile
{
    public BookHubProfile()
    {
        CreateMap<AuthorListOutputDto, AuthorListViewModel>();
        CreateMap<GenreListOutputDto, GenreListViewModel>();
        CreateMap<BookListOutputDto, BookListViewModel>();
        CreateMap<Book, BookDetailViewModel>();
        CreateMap<CartItem, CartItemViewModel>()
            .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title));
    }
}
