using BookHub.DTO.Output.User;
using DataAccessLayer.Entity;

namespace BookHub.Mapper;

public static class UserMapper
{
    public static UserListOutputDto MapList(User user)
    {
        return new UserListOutputDto()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            IsAdmin = user.IsAdmin,
        };
    }
    
    public static UserDetailOutputDto MapDetail(User user)
    {
        return new UserDetailOutputDto()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            IsAdmin = user.IsAdmin,
            Orders = user.Orders.Select(OrderMapper.MapList),
            CartItems = user.CartItems.Select(CartItemMapper.MapListWithoutUser),
            Reviews = user.Reviews.Select(ReviewMapper.MapList),
            WishLists = user.WishLists.Select(WishListMapper.MapListWithoutUser)
        };
    }
}