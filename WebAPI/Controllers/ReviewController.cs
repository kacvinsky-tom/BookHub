using AutoMapper;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Input.Review;
using WebAPI.DTO.Output.Review;
using WebAPI.Services;

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
        catch (EntityNotFoundException<User> e)
        {
            return NotFound(e.Message);
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
        catch (EntityNotFoundException<User> e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _reviewService.Delete(id);

        return Ok();
    }
}