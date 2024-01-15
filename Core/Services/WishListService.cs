using Core.DTO.Input.WishList;
using Core.DTO.Input.WishListItem;
using Core.Exception;
using DataAccessLayer;
using DataAccessLayer.Entity;

namespace Core.Services;

public class WishListService
{
    private readonly UnitOfWork _unitOfWork;

    public WishListService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<WishList>> GetAll()
    {
        return await _unitOfWork.WishLists.GetAll();
    }

    public async Task<IEnumerable<WishList>> GetAllForUser(int userId)
    {
        return await _unitOfWork.WishLists.GetAllForUser(userId);
    }

    public async Task<WishList?> GetById(int id)
    {
        return await _unitOfWork.WishLists.GetByIdWithRelations(id);
    }

    public async Task<IEnumerable<WishListItem>> GetAllItems()
    {
        return await _unitOfWork.WishListItems.GetAllWithRelations();
    }

    public async Task<WishListItem?> GetItemById(int id)
    {
        return await _unitOfWork.WishListItems.GetByIdWithRelations(id);
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

        await _unitOfWork.WishLists.Add(wishList);

        await _unitOfWork.Complete();

        return wishList;
    }

    public async Task<IEnumerable<WishList>> GetByBookId(int bookId, bool containsBook = true)
    {
        return await _unitOfWork.WishLists.GetByBookId(bookId, containsBook);
    }

    public async Task<WishList> Update(WishListInputDto wishListInputDto, int wishListId)
    {
        var wishList = await _unitOfWork.WishLists.GetByIdWithRelations(wishListId);

        if (wishList == null)
        {
            throw new EntityNotFoundException<WishList>(wishListId);
        }

        var user = await _unitOfWork.Users.GetById(wishListInputDto.UserId);

        if (user == null)
        {
            throw new EntityNotFoundException<User>(wishListInputDto.UserId);
        }

        wishList.Name = wishListInputDto.Name;
        wishList.User = user;

        await _unitOfWork.Complete();

        return wishList;
    }

    public async Task<WishListItem> CreateItemInWishlist(WishListItemInputDto wishListItemInputDto)
    {
        var wishlist = await _unitOfWork.WishLists.GetByIdWithRelations(
            wishListItemInputDto.WishListId
        );

        if (wishlist == null)
        {
            throw new EntityNotFoundException<WishList>(wishListItemInputDto.WishListId);
        }

        var book = await _unitOfWork.Books.GetById(wishListItemInputDto.BookId);

        if (book == null)
        {
            throw new EntityNotFoundException<Book>(wishListItemInputDto.BookId);
        }

        if (wishlist.WishListItems.Any(w => w.BookId == book.Id))
        {
            throw new AlreadyExistsException(
                $"Book {book.Title} is already in wishlist {wishlist.Name}"
            );
        }

        var wishListItem = new WishListItem { WishList = wishlist, Book = book, };

        await _unitOfWork.WishListItems.Add(wishListItem);

        await _unitOfWork.Complete();

        return wishListItem;
    }

    public async Task<WishListItem> UpdateItemInWishlist(
        WishListItemInputDto wishListItemInputDto,
        int wishListItemId
    )
    {
        var wishListItem = await _unitOfWork.WishListItems.GetById(wishListItemId);

        if (wishListItem == null)
        {
            throw new EntityNotFoundException<WishListItem>(wishListItemId);
        }

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

        await _unitOfWork.Complete();

        return wishListItem;
    }

    public async Task Delete(int wishListId)
    {
        var wishList = await _unitOfWork.WishLists.GetById(wishListId);

        if (wishList == null)
        {
            throw new EntityNotFoundException<WishList>(wishListId);
        }

        _unitOfWork.WishLists.Remove(wishList);

        await _unitOfWork.Complete();
    }

    public async Task DeleteItem(int wishListItemId)
    {
        var wishListItem = await _unitOfWork.WishListItems.GetById(wishListItemId);

        if (wishListItem == null)
        {
            throw new EntityNotFoundException<WishListItem>(wishListItemId);
        }

        _unitOfWork.WishListItems.Remove(wishListItem);

        await _unitOfWork.Complete();
    }

    public async Task DeleteItemByBookAndWishListId(int bookId, int wishListId)
    {
        var wishListItem = await _unitOfWork.WishListItems.GetByBookAndWishlistId(
            bookId,
            wishListId
        );

        if (wishListItem == null)
        {
            throw new EntityNotFoundException<WishListItem>(wishListId);
        }

        _unitOfWork.WishListItems.Remove(wishListItem);

        await _unitOfWork.Complete();
    }
}
