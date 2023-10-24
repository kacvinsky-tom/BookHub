using BookHub.DataAccessLayer.Dtos;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class WishListItemMapper
{
    public static WishListItemListDto MapList(WishListItem wishListItem)
    {
        return new WishListItemListDto()
        {
            Id = wishListItem.Id,
            BookTitle = wishListItem.Book.Title,
            BookPrice = wishListItem.Book.Price,
            BookReleaseYear = wishListItem.Book.ReleaseYear,
            BookImage = wishListItem.Book.Image ?? "/assets/images/404.png"
            // TODO uncomment after AuthorMapper is implemented
            // Authors = wishListItem.Book.Authors.Select(ba => AuthorMapper.MapList(ba.Author)).ToList(),
        };
    }
    
    public static WishListItemDetailDto MapDetail(WishListItem wishListItem)
    {
        return new WishListItemDetailDto()
        {
            Id = wishListItem.Id,
            BookTitle = wishListItem.Book.Title,
            BookPrice = wishListItem.Book.Price,
            BookReleaseYear = wishListItem.Book.ReleaseYear,
            BookDescription = wishListItem.Book.Description,
            BookISBN = wishListItem.Book.ISBN,
            BookImage = wishListItem.Book.Image ?? "/assets/images/404.png"
            // TODO uncomment after AuthorMapper and GenreMapper are implemented
            // Authors = wishListItem.Book.Authors.Select(ba => AuthorMapper.MapList(ba.Author)).ToList(),
            // Genres = wishListItem.Book.Genres.Select(bg => GenreMapper.MapList(bg.Genre)).ToList()
        };
    }
}