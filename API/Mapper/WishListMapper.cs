using BookHub.DataAccessLayer.Dtos;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class WishListMapper
{
    public static WishListListDto MapList(WishList wishList)
    {
        return new WishListListDto()
        {
            Id = wishList.Id,
            UserId = wishList.UserId,
            Name = wishList.Name
        };
    }

    public static WishListDetailDto MapDetail(WishList wishList)
    {
        return new WishListDetailDto()
        {
            Id = wishList.Id,
            UserId = wishList.UserId,
            Name = wishList.Name,
            WishListItems = wishList.WishListItems.Select(WishListItemMapper.MapList)
        };
    }
}