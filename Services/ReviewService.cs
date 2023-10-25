using BookHub.API.DTO.Input;
using BookHub.DataAccessLayer;
using BookHub.DataAccessLayer.Entity;
using BookHub.DataAccessLayer.Exception;

namespace BookHub.Services;

public class ReviewService
{
    private readonly UnitOfWork _unitOfWork;
    
    public ReviewService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Review> Create(ReviewInputDto reviewInputDto)
    {
        var book = await _unitOfWork.Books.GetById(reviewInputDto.BookId);
        
        if (book == null)
        {
            throw new EntityNotFoundException<Book>(reviewInputDto.BookId);
        }
        
        var user = await _unitOfWork.Users.GetById(reviewInputDto.UserId);
        
        if (user == null)
        {
            throw new EntityNotFoundException<User>(reviewInputDto.UserId);
        }
        
        var review = new Review
        {
            Book = book,
            User = user,
            Rating = reviewInputDto.Rating,
            Comment = reviewInputDto.Comment,          
        };
        
        return review;
    }
    
}