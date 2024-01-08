using Core.DTO.Input.CartItem;
using Core.Exception;
using DataAccessLayer;
using DataAccessLayer.Entity;

namespace Core.Services;

public class CartService
{
    private readonly UnitOfWork _unitOfWork;

    public CartService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CartItem>> GetAllCartItems()
    {
        return await _unitOfWork.CartItems.GetAllWithRelations();
    }

    public async Task<CartItem?> GetCartItemById(int id)
    {
        return await _unitOfWork.CartItems.GetByIdWithRelations(id);
    }

    public Task<IEnumerable<CartItem>> GetCartItemsByUserId(int userId)
    {
        return _unitOfWork.CartItems.GetByUserIdWithRelations(userId);
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

        await _unitOfWork.CartItems.Add(cartItem);
        await _unitOfWork.Complete();

        return cartItem;
    }

    public async Task<CartItem> UpdateCartItem(
        CartItemUpdateInputDto cartItemUpdateInputDto,
        int id
    )
    {
        var cartItem = await _unitOfWork.CartItems.GetByIdWithRelations(id);

        if (cartItem == null)
        {
            throw new EntityNotFoundException<CartItem>(id);
        }

        cartItem.Quantity = cartItemUpdateInputDto.Quantity;

        await _unitOfWork.Complete();

        return cartItem;
    }

    public async Task RemoveCartItem(int id)
    {
        var cartItem = await _unitOfWork.CartItems.GetById(id);

        if (cartItem == null)
        {
            throw new EntityNotFoundException<CartItem>(id);
        }

        _unitOfWork.CartItems.Remove(cartItem);

        await _unitOfWork.Complete();
    }
}
