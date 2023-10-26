using BookHub.API.DTO.Output;
using BookHub.API.DTO.Output.WishListItem;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class WishListItemMapper
{
    public static WishListItemListOutputDto MapList(WishListItem wishListItem)
    {
        return new WishListItemListOutputDto()
        {
            Id = wishListItem.Id,
            BookTitle = wishListItem.Book?.Title,
            BookPrice = wishListItem.Book?.Price ?? -1,
            BookReleaseYear = wishListItem.Book?.ReleaseYear ?? -1,
            BookImage = wishListItem.Book?.Image ?? "/assets/images/404.png"
            // TODO uncomment after AuthorMapper is implemented
            // Authors = wishListItem.Book.Authors.Select(ba => AuthorMapper.MapList(ba.Author)).ToList(),
        };
    }
    
    public static WishListItemDetailOutputDto MapDetail(WishListItem wishListItem)
    {
        return new WishListItemDetailOutputDto()
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