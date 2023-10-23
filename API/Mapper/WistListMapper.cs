using BookHub.DataAccessLayer.Dtos;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class WistListMapper
{
    public static WishListListDto MapList(WishList wistList)
    {
        return new WishListListDto()
        {
            // TODO
        };
    }

    public static WishListDetailDto MapDetail(WishList wishList)
    {
        return new WishListDetailDto()
        {
            // TODO
        };
    }
}