using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.WishListItem;
using WebAPI.DTO.Output.WishListItem;
using WebAPI.Services;

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
        catch (EntityNotFoundException<BaseEntity> e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] WishListItemInputDto wishListItemInputDto)
    {
        try
        {
            var wishListItem = await _wishListService.UpdateItemInWishlist(wishListItemInputDto, id);

            return Ok(_mapper.Map<WishListItemDetailOutputDto>(wishListItem));
        }
        catch (EntityNotFoundException<BaseEntity> e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _wishListService.DeleteItem(id);
        
        return Ok();
    }
}