using AutoMapper;
using Core.DTO.Input.Author;
using Core.DTO.Input.Book;
using Core.DTO.Input.CartItem;
using Core.DTO.Input.Genre;
using Core.DTO.Input.Order;
using Core.DTO.Input.OrderItem;
using Core.DTO.Input.Publisher;
using Core.DTO.Input.Review;
using Core.DTO.Input.User;
using Core.DTO.Input.Voucher;
using Core.DTO.Input.WishList;
using Core.DTO.Input.WishListItem;
using Core.DTO.Output.Author;
using Core.DTO.Output.Book;
using Core.DTO.Output.CartItem;
using Core.DTO.Output.Genre;
using Core.DTO.Output.Order;
using Core.DTO.Output.OrderItem;
using Core.DTO.Output.Publisher;
using Core.DTO.Output.Review;
using Core.DTO.Output.User;
using Core.DTO.Output.Voucher;
using Core.DTO.Output.WishList;
using Core.DTO.Output.WishListItem;
using DataAccessLayer.Entity;
using DataAccessLayer.Filter;

namespace WebAPI;

public class BookHubProfile : Profile
{
    public BookHubProfile()
    {
        // Input
        CreateMap<AuthorInputDto, Author>();
        CreateMap<BookCreateInputDto, Book>();
        CreateMap<BookFilterInputDto, BookFilter>();
        CreateMap<BookFilterInputDto, Book>();
        CreateMap<CartItemCreateInputDto, CartItem>();
        CreateMap<CartItemUpdateInputDto, CartItem>();
        CreateMap<GenreInputDto, Genre>();
        CreateMap<OrderCreateInputDto, Order>();
        CreateMap<OrderUpdateInputDto, Order>();
        CreateMap<OrderItemCreateInputDto, OrderItem>();
        CreateMap<PublisherInputDto, Publisher>();
        CreateMap<ReviewCreateInputDto, Review>();
        CreateMap<ReviewUpdateInputDto, Review>();
        CreateMap<UserInputDto, User>();
        CreateMap<VoucherInputDto, Voucher>();
        CreateMap<WishListInputDto, WishList>();
        CreateMap<WishListItemInputDto, WishListItem>();

        // Output
        CreateMap<Author, AuthorDetailOutputDto>();
        CreateMap<Author, AuthorListOutputDto>();
        CreateMap<Book, BookDetailOutputDto>();
        CreateMap<Book, BookListOutputDto>();
        CreateMap<Book, BookListWithoutAuthorOutputDto>();
        CreateMap<CartItem, CartItemDetailOutputDto>();
        CreateMap<CartItem, CartItemListOutputDto>();
        CreateMap<CartItem, CartItemListWithoutUserOutputDto>();
        CreateMap<Genre, GenreDetailOutputDto>();
        CreateMap<BookGenre, BookGenreListOutputDto>();
        CreateMap<Order, OrderDetailOutputDto>();
        CreateMap<Order, OrderListOutputDto>();
        CreateMap<OrderItem, OrderItemCreateInputDto>();
        CreateMap<OrderItem, OrderItemDetailOutputDto>();
        CreateMap<OrderItem, OrderItemListOutputDto>();
        CreateMap<Publisher, PublisherDetailOutputDto>();
        CreateMap<Publisher, PublisherListOutputDto>();
        CreateMap<Review, ReviewDetailOutputDto>();
        CreateMap<Review, ReviewListOutputDto>();
        CreateMap<User, UserDetailOutputDto>();
        CreateMap<User, UserListOutputDto>();
        CreateMap<Voucher, VoucherDetailOutputDto>();
        CreateMap<Voucher, VoucherListOutputDto>();
        CreateMap<WishList, WishListDetailOutputDto>();
        CreateMap<WishList, WishListListOutputDto>();
        CreateMap<WishList, WishListListWithoutUserOutputDto>();
        CreateMap<WishListItem, WishListItemDetailOutputDto>();
        CreateMap<WishListItem, WishListItemListOutputDto>();
    }
}
