using AutoMapper;
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
    private readonly WishListService _wishListService;
    private readonly IMapper _mapper;

    public WishListController(WishListService wishListService, IMapper mapper)
    {
        _wishListService = wishListService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var wishLists = await _wishListService.GetAll();
        
        return Ok(wishLists.Select(_mapper.Map<WishListListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var wishList = await _wishListService.GetById(id);
        
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
        try
        {
            var wishList = await _wishListService.Update(wishListInputDto, id);

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
        await _wishListService.Delete(id);

        return Ok();
    }
}