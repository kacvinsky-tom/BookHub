using AutoMapper;
using DataAccessLayer;
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
    private readonly UnitOfWork _unitOfWork;
    private readonly CartService _cartService;
    private readonly IMapper _mapper;

    public CartItemController(UnitOfWork unitOfWork, CartService cartService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _cartService = cartService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var cartItems = await _unitOfWork.CartItems.GetAllWithRelations();

        return Ok(cartItems.Select(_mapper.Map<CartItemListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var cartItem = await _unitOfWork.CartItems.GetByIdWithRelations(id);

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
            _unitOfWork.CartItems.Add(cartItem);
            await _unitOfWork.Complete();
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
        var cartItem = await _unitOfWork.CartItems.GetByIdWithRelations(id);

        if (cartItem == null)
        {
            return NotFound();
        }

        cartItem.Quantity = cartItemUpdateInputDto.Quantity;
        await _unitOfWork.Complete();
        return Ok(_mapper.Map<CartItemDetailOutputDto>(cartItem));
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