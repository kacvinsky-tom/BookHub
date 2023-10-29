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
            BookImage = wishListItem.Book?.Image ?? "/assets/images/404.png",
            Authors = wishListItem.Book.Authors.Select(AuthorMapper.MapList).ToList(),
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
            BookImage = wishListItem.Book.Image ?? "/assets/images/404.png",
            Authors = wishListItem.Book.Authors.Select(AuthorMapper.MapList).ToList(),
            Genres = wishListItem.Book.Genres.Select(GenreMapper.MapList).ToList()
        };
    }
}