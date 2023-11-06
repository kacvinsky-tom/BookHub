using AutoMapper;
using DataAccessLayer;
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
    private readonly UnitOfWork _unitOfWork;
    private readonly ReviewService _reviewService;
    private readonly IMapper _mapper;

    public ReviewController(UnitOfWork unitOfWork, ReviewService reviewService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _reviewService = reviewService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Fetch()
    {
        var reviews = await _unitOfWork.Reviews.GetAllWithRelations();
        
        return Ok(reviews.Select(_mapper.Map<ReviewListOutputDto>));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Fetch(int id)
    {
        var review = await _unitOfWork.Reviews.GetByIdWithRelations(id);
        
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
            _unitOfWork.Reviews.Add(review);
            await _unitOfWork.Complete();
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