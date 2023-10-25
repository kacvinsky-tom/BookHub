using BookHub.API.DTO.Input;
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
public class ReviewController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly ReviewService _reviewService;
    
    public ReviewController(UnitOfWork unitOfWork, ReviewService reviewService)
    {
        _unitOfWork = unitOfWork;
        _reviewService = reviewService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var reviews = await _unitOfWork.Reviews.GetAllWithRelations();
        
        return Ok(reviews.Select(ReviewMapper.MapList));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var review = await _unitOfWork.Reviews.GetByIdWithRelations(id);
        
        if (review == null)
        {
            return NotFound();
        }

        return Ok(ReviewMapper.MapDetail(review));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReviewInputDto reviewInputDto)
    {
        try
        {
            var review = await _reviewService.Create(reviewInputDto);
            _unitOfWork.Reviews.Add(review);
            await _unitOfWork.Complete();
            return Ok(ReviewMapper.MapDetail(review));
        }
        catch (EntityNotFoundException<User> e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ReviewUpdateInputDto reviewInputDto)
    {
        var review = await _unitOfWork.Reviews.GetById(id);
        
        if (review == null)
        {
            return NotFound();
        }

        try
        {
            review.Rating = reviewInputDto.Rating;
            review.Comment = reviewInputDto.Comment;
            await _unitOfWork.Complete();
            return Ok(ReviewMapper.MapDetail(review));
        }
        catch (EntityNotFoundException<User> e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var review = await _unitOfWork.Reviews.GetById(id);
        
        if (review == null)
        {
            return NotFound();
        }

        _unitOfWork.Reviews.Remove(review);
        await _unitOfWork.Complete();
        return Ok();
    }
}