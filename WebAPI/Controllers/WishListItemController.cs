using AutoMapper;
using Core.DTO.Input.WishListItem;
using Core.DTO.Output.WishListItem;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListItemController : ControllerBase
{
    private readonly WishListService _wishListService;
    private readonly IMapper _mapper;

    public WishListItemController(WishListService wishListService, IMapper mapper)
    {
        _wishListService = wishListService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var wishListItems = await _wishListService.GetAllItems();

        return Ok(wishListItems.Select(_mapper.Map<WishListItemListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var wishListItem = await _wishListService.GetItemById(id);

        if (wishListItem == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<WishListItemDetailOutputDto>(wishListItem));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WishListItemInputDto wishListItemInputDto)
    {
        try
        {
            var wishListItem = await _wishListService.CreateItemInWishlist(wishListItemInputDto);

            return Ok(_mapper.Map<WishListItemDetailOutputDto>(wishListItem));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] WishListItemInputDto wishListItemInputDto
    )
    {
        try
        {
            var wishListItem = await _wishListService.UpdateItemInWishlist(
                wishListItemInputDto,
                id
            );

            return Ok(_mapper.Map<WishListItemDetailOutputDto>(wishListItem));
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
            await _wishListService.DeleteItem(id);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}
