using AutoMapper;
using Core.DTO.Input.CartItem;
using Core.DTO.Output.CartItem;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CartItemController : ControllerBase
{
    private readonly CartService _cartService;
    private readonly IMapper _mapper;

    public CartItemController(CartService cartService, IMapper mapper)
    {
        _cartService = cartService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var cartItems = await _cartService.GetAllCartItems();

        return Ok(cartItems.Select(_mapper.Map<CartItemListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var cartItem = await _cartService.GetCartItemById(id);

        if (cartItem == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CartItemDetailOutputDto>(cartItem));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CartItemCreateInputDto cartItemCreateInputDto)
    {
        try
        {
            var cartItem = await _cartService.CreateCartItem(cartItemCreateInputDto);

            return Ok(_mapper.Map<CartItemDetailOutputDto>(cartItem));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CartItemUpdateInputDto cartItemUpdateInputDto)
    {
        try
        {
            var cartItem = await _cartService.UpdateCartItem(cartItemUpdateInputDto, id);
            
            return Ok(_mapper.Map<CartItemDetailOutputDto>(cartItem));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _cartService.RemoveCartItem(id);
        
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}