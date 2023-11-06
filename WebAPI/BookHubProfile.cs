using AutoMapper;
using DataAccessLayer.Entity;
using WebAPI.DTO.Input.Author;
using WebAPI.DTO.Input.Book;
using WebAPI.DTO.Input.CartItem;
using WebAPI.DTO.Input.Genre;
using WebAPI.DTO.Input.Order;
using WebAPI.DTO.Input.OrderItem;
using WebAPI.DTO.Input.Publisher;
using WebAPI.DTO.Input.Review;
using WebAPI.DTO.Input.User;
using WebAPI.DTO.Input.Voucher;
using WebAPI.DTO.Input.WishList;
using WebAPI.DTO.Input.WishListItem;
using WebAPI.DTO.Output.Author;
using WebAPI.DTO.Output.Book;
using WebAPI.DTO.Output.CartItem;
using WebAPI.DTO.Output.Genre;
using WebAPI.DTO.Output.Order;
using WebAPI.DTO.Output.OrderItem;
using WebAPI.DTO.Output.Publisher;
using WebAPI.DTO.Output.Review;
using WebAPI.DTO.Output.User;
using WebAPI.DTO.Output.Voucher;
using WebAPI.DTO.Output.WishList;
using WebAPI.DTO.Output.WishListItem;

namespace WebAPI;

public class BookHubProfile : Profile
{
    public BookHubProfile()
    {
        // Input
        CreateMap<AuthorInputDto, Author>();
        CreateMap<BookCreateInputDto, Book>();
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
        CreateMap<Genre, GenreListOutputDto>();
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