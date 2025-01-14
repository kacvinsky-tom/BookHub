﻿using Core.DTO.Input.Review;
using Core.Exception;
using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Services;

public class ReviewService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMemoryCache _memoryCache;

    public ReviewService(UnitOfWork unitOfWork, IMemoryCache memoryCache)
    {
        _unitOfWork = unitOfWork;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<Review>> GetAll()
    {
        return await _unitOfWork.Reviews.GetAllWithRelations();
    }

    public async Task<Review?> GetById(int id)
    {
        if (_memoryCache.TryGetValue("review-" + id, out Review? cachedReview))
        {
            return cachedReview;
        }

        var review = await _unitOfWork.Reviews.GetByIdWithRelations(id);

        if (review != null)
        {
            _memoryCache.Set("review-" + id, review);
        }

        return review;
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

        await _unitOfWork.Reviews.Add(review);

        await _unitOfWork.Complete();

        return review;
    }

    public async Task<Review> Update(ReviewUpdateInputDto reviewInputDto, int reviewId)
    {
        var review = await _unitOfWork.Reviews.GetById(reviewId);

        if (review == null)
        {
            throw new EntityNotFoundException<Review>(reviewId);
        }

        review.Rating = reviewInputDto.Rating;
        review.Comment = reviewInputDto.Comment;

        await _unitOfWork.Complete();

        _memoryCache.Set("review-" + reviewId, review);

        return review;
    }

    public async Task Delete(int reviewId)
    {
        var review = await _unitOfWork.Reviews.GetById(reviewId);

        if (review == null)
        {
            throw new EntityNotFoundException<Review>(reviewId);
        }

        _unitOfWork.Reviews.Remove(review);

        await _unitOfWork.Complete();

        _memoryCache.Remove("review-" + reviewId);
    }
}
