using AutoMapper;
using Core.DTO.Input.Author;
using Core.DTO.Input.Book;
using Core.DTO.Input.Genre;
using Core.DTO.Input.LocalIdentityUser;
using Core.DTO.Input.Publisher;
using Core.DTO.Input.Review;
using Core.DTO.Input.User;
using Core.DTO.Input.Voucher;
using Core.DTO.Output;
using Core.DTO.Output.Author;
using Core.DTO.Output.Book;
using Core.DTO.Output.Genre;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;
using DataAccessLayer.Filter;

namespace Core;

public class ServicesBookHubProfile : Profile
{
    public ServicesBookHubProfile()
    {
        CreateMap<Author, AuthorListOutputDto>();
        CreateMap<AuthorInputDto, Author>();
        CreateMap<BookCreateInputDto, Book>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        CreateMap<Book, BookListOutputDto>();
        CreateMap<Genre, BookGenreListOutputDto>();
        CreateMap<Genre, GenreListOutputDto>();
        CreateMap<GenreInputDto, Genre>();
        CreateMap<BookFilterInputDto, BookFilter>();
        CreateMap<LocalIdentityUserInputDto, UserInputDto>();
        CreateMap<LocalIdentityUserInputDto, LocalIdentityUser>();
        CreateMap<SimpleListResult, SimpleListDto>();
        CreateMap<PublisherInputDto, Publisher>();
        CreateMap<ReviewCreateInputDto, Review>();
        CreateMap<VoucherInputDto, Voucher>();
        CreateMap<UserInputDto, User>();
    }
}
