using AutoMapper;
using Core.DTO.Input.Review;
using Core.DTO.Output.Review;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase
{
    private readonly ReviewService _reviewService;
    private readonly IMapper _mapper;

    public ReviewController(ReviewService reviewService, IMapper mapper)
    {
        _reviewService = reviewService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var reviews = await _reviewService.GetAll();

        return Ok(reviews.Select(_mapper.Map<ReviewListOutputDto>));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var review = await _reviewService.GetById(id);
        
        if (review == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ReviewDetailOutputDto>(review));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReviewCreateInputDto reviewCreateInputDto)
    {
        try
        {
            var review = await _reviewService.Create(reviewCreateInputDto);

            return Ok(_mapper.Map<ReviewDetailOutputDto>(review));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ReviewUpdateInputDto reviewInputDto)
    {
        try
        {
            var review = await _reviewService.Update(reviewInputDto, id);

            return Ok(_mapper.Map<ReviewDetailOutputDto>(review));
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
            await _reviewService.Delete(id);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}