﻿using BookHub.API.DTO.Output.CartItem;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class CartItemMapper
{
    public static CartItemOutputDto Map(CartItem cartList)
    {
        return new CartItemOutputDto()
        {
            // TODO
        };
}
}