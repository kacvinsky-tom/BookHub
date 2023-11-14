using AutoMapper;
using Core.DTO.Input.WishList;
using Core.DTO.Output.WishList;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

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
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
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
            await _wishListService.Delete(id);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}