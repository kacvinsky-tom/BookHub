using BookHub.API.DTO.Output.CartItem;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class CartItemMapper
{
    public static CartItemListOutputDto MapList(CartItem cartItem)
    {
        return new CartItemListOutputDto()
        {
            Id = cartItem.Id,
            UserFirstName = cartItem.User.FirstName,
            UserLastName = cartItem.User.LastName,
            BookTitle = cartItem.Book.Title,
            BookId = cartItem.Book.Id,
            Quantity = cartItem.Quantity
        };
    }

    public static CartItemListWithoutUserOutputDto MapListWithoutUser(CartItem cartItem)
    {
        return new CartItemListWithoutUserOutputDto()
        {
            Id = cartItem.Id,
            BookTitle = cartItem.Book.Title,
            BookId = cartItem.Book.Id,
            Quantity = cartItem.Quantity
        };
    }

    public static CartItemDetailOutputDto MapDetail(CartItem cartItem)
    {
        return new CartItemDetailOutputDto()
        {
            Id = cartItem.Id,
            User = UserMapper.MapList(cartItem.User),
            Book = BookMapper.MapList(cartItem.Book),
            Quantity = cartItem.Quantity
        };
    }

}