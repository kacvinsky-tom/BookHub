using DataAccessLayer.Entity;
using WebAPI.DTO.Output.WishList;

namespace WebAPI.Mapper;

public static class WishListMapper
{
    public static WishListListOutputDto MapList(WishList wishList)
    {
        return new WishListListOutputDto
        {
            Id = wishList.Id,
            UserId = wishList.UserId,
            Name = wishList.Name
        };
    }

    public static WishListDetailOutputDto MapDetail(WishList wishList)
    {
        return new WishListDetailOutputDto
        {
            Id = wishList.Id,
            UserId = wishList.UserId,
            Name = wishList.Name,
            WishListItems = wishList.WishListItems.Select(WishListItemMapper.MapList)
        };
    }

    public static WishListListWithoutUserOutputDto MapListWithoutUser(WishList wishList)
    {
        return new WishListListWithoutUserOutputDto
        {
            Id = wishList.Id,
            Name = wishList.Name
        };
    }

}