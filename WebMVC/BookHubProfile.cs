using AutoMapper;
using Core.DTO.Output.Author;
using Core.DTO.Output.Book;
using Core.DTO.Output.Genre;

namespace WebMVC;

public class BookHubProfile : Profile
{
    public BookHubProfile()
    {
        CreateMap<AuthorListOutputDto, AuthorListViewModel>();
        CreateMap<GenreListOutputDto, GenreListViewModel>();
        CreateMap<BookListOutputDto, BookListViewModel>();
    }
}
