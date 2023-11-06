using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.WishList;
using WebAPI.DTO.Output.WishList;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly WishListService _wishListService;
    private readonly IMapper _mapper;

    public WishListController(UnitOfWork unitOfWork, WishListService wishListService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _wishListService = wishListService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var wishLists = await _unitOfWork.WishLists.GetAll();
        
        return Ok(wishLists.Select(_mapper.Map<WishListListOutputDto>));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var wishList = await _unitOfWork.WishLists.GetByIdWithRelations(id);
        
        if (wishList == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<WishListDetailOutputDto>(wishList));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WishListInputDto wishListInputDto)
    {
        try
        {
            var wishList = await _wishListService.Create(wishListInputDto);
            _unitOfWork.WishLists.Add(wishList);
            await _unitOfWork.Complete();
            return Ok(_mapper.Map<WishListDetailOutputDto>(wishList));
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
            return Ok(_mapper.Map<WishListDetailOutputDto>(wishList));
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