using AutoMapper;
using Core.DTO.Input.Review;
using Core.DTO.Input.WishList;
using Core.DTO.Input.WishListItem;
using Core.DTO.Output.Author;
using Core.DTO.Output.Book;
using Core.DTO.Output.Genre;
using Core.DTO.Output.Review;
using DataAccessLayer.Entity;
using DataAccessLayer.Helpers;
using WebMVC.Areas.Admin.ViewModels.Order;
using WebMVC.Areas.Admin.ViewModels.Publisher;
using WebMVC.Areas.Admin.ViewModels.User;
using WebMVC.Areas.Shop.ViewModel.Book;
using WebMVC.Areas.Shop.ViewModel.CartItem;
using WebMVC.Areas.Shop.ViewModel.Review;
using WebMVC.Areas.Shop.ViewModel.WishList;
using WebMVC.ViewModels;

namespace WebMVC;

public class BookHubProfile : Profile
{
    public BookHubProfile()
    {
        CreateMap<AuthorListOutputDto, AuthorListViewModel>();
        CreateMap<Author, AuthorListViewModel>();
        CreateMap<GenreListOutputDto, GenreListViewModel>();
        CreateMap<BookListOutputDto, BookListViewModel>();
        CreateMap<Book, BookDetailViewModel>();
        CreateMap<Author, AuthorEditViewModel>();
        CreateMap<Genre, GenreEditViewModel>();
        CreateMap<Publisher, PublisherEditViewModel>();
        CreateMap<Genre, GenreListViewModel>();
        CreateMap<Publisher, PublisherListViewModel>();
        CreateMap<Review, ReviewDetailViewModel>();
        CreateMap<WishList, WishListDetailViewModel>();
        CreateMap<WishList, WishListListViewModel>();
        CreateMap<ReviewDetailOutputDto, ReviewDetailViewModel>();
        CreateMap<ReviewCreateViewModel, ReviewCreateInputDto>();
        CreateMap<WishListItemsEditViewModel, WishListItemInputDto>();
        CreateMap<WishListItem, WishListItemListViewModel>();
        CreateMap<WishListCreateViewModel, WishListInputDto>();
        CreateMap<WishListEditViewModel, WishListInputDto>();

        CreateMap<Book, Areas.Admin.ViewModels.Book.BookListViewModel>()
            .ForMember(
                dest => dest.BookAuthors,
                opt =>
                    opt.MapFrom(src =>
                        string.Join(
                            ", ",
                            src.BookAuthors.Select(x =>
                                x.Author.FirstName + " " + x.Author.LastName
                            )
                        )
                    )
            );

        CreateMap<LocalIdentityUser, UserListViewModel>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName)
            );

        CreateMap<Order, OrderListViewModel>()
            .ForMember(
                dest => dest.UserFullName,
                opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName)
            )
            .ForMember(dest => dest.ItemsCount, opt => opt.MapFrom(src => src.OrderItems.Count()));

        CreateMap<PaginationObject<Author>, PaginationViewModel<AuthorListViewModel>>();
        CreateMap<
            PaginationObject<Book>,
            PaginationViewModel<Areas.Admin.ViewModels.Book.BookListViewModel>
        >();
        CreateMap<PaginationObject<Genre>, PaginationViewModel<GenreListViewModel>>();
        CreateMap<PaginationObject<Publisher>, PaginationViewModel<PublisherListViewModel>>();
        CreateMap<PaginationObject<LocalIdentityUser>, PaginationViewModel<UserListViewModel>>();
        CreateMap<PaginationObject<Order>, PaginationViewModel<OrderListViewModel>>();

        CreateMap<CartItem, CartItemViewModel>()
            .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title));
    }
}
