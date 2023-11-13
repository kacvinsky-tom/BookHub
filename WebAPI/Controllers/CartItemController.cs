using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.CartItem;
using WebAPI.DTO.Output.CartItem;
using WebAPI.Services;

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
        catch (EntityNotFoundException<User> e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CartItemUpdateInputDto cartItemUpdateInputDto)
    {
        var cartItem = await _cartService.UpdateCartItem(cartItemUpdateInputDto, id);

        return Ok(_mapper.Map<CartItemDetailOutputDto>(cartItem));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _cartService.RemoveCartItem(id);
        
        return Ok();
    }
}