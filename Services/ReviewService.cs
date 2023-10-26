﻿using BookHub.API.DTO.Input;
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
    
    public async Task<Review> Create(ReviewCreateInputDto reviewCreateInputDto)
    {
        var book = await _unitOfWork.Books.GetById(reviewCreateInputDto.BookId);
        
        if (book == null)
        {
            throw new EntityNotFoundException<Book>(reviewCreateInputDto.BookId);
        }
        
        var user = await _unitOfWork.Users.GetById(reviewCreateInputDto.UserId);
        
        if (user == null)
        {
            throw new EntityNotFoundException<User>(reviewCreateInputDto.UserId);
        }
        
        var review = new Review
        {
            Book = book,
            User = user,
            Rating = reviewCreateInputDto.Rating,
            Comment = reviewCreateInputDto.Comment,          
        };
        
        return review;
    }
    
}