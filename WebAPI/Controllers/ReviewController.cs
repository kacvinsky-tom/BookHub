using AutoMapper;
using Core.DTO.Input.Review;
using Core.DTO.Output.Review;
using Core.Exception;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebAPI.Extensions;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase
{
    private readonly ReviewService _reviewService;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public ReviewController(ReviewService reviewService, IMapper mapper, IMemoryCache memoryCache)
    {
        _reviewService = reviewService;
        _mapper = mapper;
        _memoryCache = memoryCache;
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
        if (_memoryCache.TryGetValue("review-" + id, out var cachedReview))
        {
            return Ok(cachedReview);
        }

        var review = await _reviewService.GetById(id);

        if (review == null)
        {
            return NotFound();
        }

        var reviewDetailDto = _mapper.Map<ReviewDetailOutputDto>(review);

        _memoryCache.Set("review-" + id, reviewDetailDto);

        return Ok(reviewDetailDto);
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

            var reviewDetailDto = _mapper.Map<ReviewDetailOutputDto>(review);

            _memoryCache.Set("review-" + id, reviewDetailDto);

            return Ok(reviewDetailDto);
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

            _memoryCache.Remove("review-" + id);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.GetApiMessage());
        }
    }
}
