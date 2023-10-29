﻿using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using WebAPI.DTO.Input.CartItem;

namespace WebAPI.Services;

public class CartService
{
    private readonly UnitOfWork _unitOfWork;

    public CartService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CartItem> CreateCartItem(CartItemCreateInputDto cartItemCreateInputDto)
    {
        var book = await _unitOfWork.Books.GetById(cartItemCreateInputDto.BookId);

        if (book == null)
        {
            throw new EntityNotFoundException<Book>(cartItemCreateInputDto.BookId);
        }

        var user = await _unitOfWork.Users.GetById(cartItemCreateInputDto.UserId);

        if (user == null)
        {
            throw new EntityNotFoundException<User>(cartItemCreateInputDto.UserId);
        }

        var cartItem = new CartItem
        {
            Book = book,
            User = user,
            Quantity = cartItemCreateInputDto.Quantity,
        };

        return cartItem;
    }

}