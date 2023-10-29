using BookHub.DTO.Input.CartItem;
using BookHub.Mapper;
using BookHub.Services;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.Controllers;

[ApiController]
[Route("[controller]")]
public class CartItemController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly CartService _cartService;

    public CartItemController(UnitOfWork unitOfWork, CartService cartService)
    {
        _unitOfWork = unitOfWork;
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var cartItems = await _unitOfWork.CartItems.GetAllWithRelations();

        return Ok(cartItems.Select(CartItemMapper.MapList));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var cartItem = await _unitOfWork.CartItems.GetByIdWithRelations(id);

        if (cartItem == null)
        {
            return NotFound();
        }

        return Ok(CartItemMapper.MapDetail(cartItem));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CartItemCreateInputDto cartItemCreateInputDto)
    {
        try
        {
            var cartItem = await _cartService.CreateCartItem(cartItemCreateInputDto);
            _unitOfWork.CartItems.Add(cartItem);
            await _unitOfWork.Complete();
            return Ok(CartItemMapper.MapDetail(cartItem));
        }
        catch (EntityNotFoundException<User> e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CartItemUpdateInputDto cartItemUpdateInputDto)
    {
        var cartItem = await _unitOfWork.CartItems.GetByIdWithRelations(id);

        if (cartItem == null)
        {
            return NotFound();
        }

        cartItem.Quantity = cartItemUpdateInputDto.Quantity;
        await _unitOfWork.Complete();
        return Ok(CartItemMapper.MapList(cartItem));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cartItem = await _unitOfWork.CartItems.GetById(id);

        if (cartItem == null)
        {
            return NotFound();
        }

        _unitOfWork.CartItems.Remove(cartItem);
        await _unitOfWork.Complete();
        return Ok();
    }
}