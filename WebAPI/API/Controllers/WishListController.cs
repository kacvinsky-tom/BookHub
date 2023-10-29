using BookHub.API.DTO.Input;
using BookHub.API.InputType;
using BookHub.API.Mapper;
using BookHub.Services;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using Microsoft.AspNetCore.Mvc;

namespace BookHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly WishListService _wishListService;
    
    public WishListController(UnitOfWork unitOfWork, WishListService wishListService)
    {
        _unitOfWork = unitOfWork;
        _wishListService = wishListService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var wishLists = await _unitOfWork.WishLists.GetAll();
        
        return Ok(wishLists.Select(WishListMapper.MapList));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var wishList = await _unitOfWork.WishLists.GetByIdWithRelations(id);
        
        if (wishList == null)
        {
            return NotFound();
        }

        return Ok(WishListMapper.MapDetail(wishList));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WishListInputDto wishListInputDto)
    {
        try
        {
            var wishList = await _wishListService.Create(wishListInputDto);
            _unitOfWork.WishLists.Add(wishList);
            await _unitOfWork.Complete();
            return Ok(WishListMapper.MapDetail(wishList));
        }
        catch (EntityNotFoundException<User> e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] WishListInputDto wishListInputDto)
    {
        var wishList = await _unitOfWork.WishLists.GetByIdWithRelations(id);
        
        if (wishList == null)
        {
            return NotFound();
        }

        try
        {
            await _wishListService.Update(wishListInputDto, wishList);
            await _unitOfWork.Complete();
            return Ok(WishListMapper.MapDetail(wishList));
        } 
        catch (EntityNotFoundException<User> e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var wishList = await _unitOfWork.WishLists.GetById(id);
        
        if (wishList == null)
        {
            return NotFound();
        }

        _unitOfWork.WishLists.Remove(wishList);
        
        await _unitOfWork.Complete();

        return Ok();
    }
}