using AutoMapper;
using Core.DTO.Output.Author;
using Core.DTO.Output.Book;
using Core.DTO.Output.Genre;
using DataAccessLayer.Entity;

namespace Core;

public class ServicesBookHubProfile : Profile
{
    public ServicesBookHubProfile()
    {
        CreateMap<Author, AuthorListOutputDto>();
        CreateMap<Book, BookListOutputDto>();
        CreateMap<Genre, BookGenreListOutputDto>();
        CreateMap<Genre, GenreListOutputDto>();
    }
}
