using BookHub.API.DTO.Output;
using BookHub.DataAccessLayer.Dtos;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class WishListMapper
{
    public static WishListListOutputDto MapList(WishList wishList)
    {
        return new WishListListOutputDto()
        {
            Id = wishList.Id,
            UserId = wishList.UserId,
            Name = wishList.Name
        };
    }

    public static WishListDetailOutputDto MapDetail(WishList wishList)
    {
        return new WishListDetailOutputDto()
        {
            Id = wishList.Id,
            UserId = wishList.UserId,
            Name = wishList.Name,
            WishListItems = wishList.WishListItems.Select(WishListItemMapper.MapList)
        };
    }
}