using BookHub.API.InputType;
using BookHub.API.Mapper;
using BookHub.DataAccessLayer;
using BookHub.DataAccessLayer.Entity;
using BookHub.DataAccessLayer.Exception;
using BookHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListItemController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly WishListService _wishListService;

    public WishListItemController(UnitOfWork unitOfWork, WishListService wishListService)
    {
        _unitOfWork = unitOfWork;
        _wishListService = wishListService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var wishListItems = await _unitOfWork.WishListItems.GetAll();
        
        return Ok(wishListItems.Select(WishListItemMapper.MapList));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var wishListItem = await _unitOfWork.WishListItems.GetByIdWithRelations(id);
        
        if (wishListItem == null)
        {
            return NotFound();
        }

        return Ok(WishListItemMapper.MapDetail(wishListItem));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WishListItemInputDto wishListItemInputDto)
    {
        try
        {
            var wishListItem = await _wishListService.CreateItemInWishlist(wishListItemInputDto);
            _unitOfWork.WishListItems.Add(wishListItem);
            await _unitOfWork.Complete();
            return Ok(WishListItemMapper.MapDetail(wishListItem));
        }
        catch (EntityNotFoundException<WishList> e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] WishListItemInputDto wishListItemInputDto)
    {
        var wishListItem = await _unitOfWork.WishListItems.GetById(id);
        
        if (wishListItem == null)
        {
            return NotFound();
        }

        try
        {
            await _wishListService.UpdateItemInWishlist(wishListItemInputDto, wishListItem);
            await _unitOfWork.Complete();
            return Ok(WishListItemMapper.MapDetail(wishListItem));
        }
        catch (EntityNotFoundException<WishList> e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var wishListItem = await _unitOfWork.WishListItems.GetById(id);
        
        if (wishListItem == null)
        {
            return NotFound();
        }

        _unitOfWork.WishListItems.Remove(wishListItem);
        await _unitOfWork.Complete();
        
        return Ok();
    }
}