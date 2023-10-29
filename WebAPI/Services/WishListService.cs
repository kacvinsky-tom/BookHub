using BookHub.DTO.Input.WishList;
using BookHub.DTO.Input.WishListItem;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;

namespace BookHub.Services;

public class WishListService
{
    private readonly UnitOfWork _unitOfWork;
    
    public WishListService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<WishList> Create(WishListInputDto wishListInputDto)
    {
        var user = await _unitOfWork.Users.GetById(wishListInputDto.UserId);

        if (user == null)
        {
            throw new EntityNotFoundException<User>(wishListInputDto.UserId);
        }
        
        var wishList = new WishList
        {
            UserId = wishListInputDto.UserId,
            Name = wishListInputDto.Name,
            User = user,
        };

        return wishList;
    }

    public async Task Update(WishListInputDto wishListInputDto, WishList wishList)
    {
        var user = await _unitOfWork.Users.GetById(wishListInputDto.UserId);

        if (user == null)
        {
            throw new EntityNotFoundException<User>(wishListInputDto.UserId);
        }
        
        wishList.Name = wishListInputDto.Name;
        wishList.User = user;
    }

    public async Task<WishListItem> CreateItemInWishlist(WishListItemInputDto wishListItemInputDto)
    {
        var wishlist = await _unitOfWork.WishLists.GetById(wishListItemInputDto.WishListId);

        if (wishlist == null)
        {
            throw new EntityNotFoundException<WishList>(wishListItemInputDto.WishListId);
        }

        var book = await _unitOfWork.Books.GetById(wishListItemInputDto.BookId);

        if (book == null)
        {
            throw new EntityNotFoundException<Book>(wishListItemInputDto.BookId);
        }
        
        var wishListItem = new WishListItem
        {
            WishList = wishlist,
            Book = book,
        };

        return wishListItem;
    }
    
    public async Task UpdateItemInWishlist(WishListItemInputDto wishListItemInputDto, WishListItem wishListItem)
    {
        var wishlist = await _unitOfWork.WishLists.GetById(wishListItemInputDto.WishListId);

        if (wishlist == null)
        {
            throw new EntityNotFoundException<WishList>(wishListItemInputDto.WishListId);
        }

        var book = await _unitOfWork.Books.GetById(wishListItemInputDto.BookId);

        if (book == null)
        {
            throw new EntityNotFoundException<Book>(wishListItemInputDto.BookId);
        }
        
        wishListItem.WishList = wishlist;
        wishListItem.Book = book;
    }
}