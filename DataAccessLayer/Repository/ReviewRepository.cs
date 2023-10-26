﻿using BookHub.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookHub.DataAccessLayer.Repository;

public class ReviewRepository : GenericRepository<Review>, IReviewRepository
{
    public ReviewRepository(BookHubDbContext context) : base(context)
    {
    }

    public async Task<Review?> GetByIdWithRelations(int id)
    {
        return await _context.Reviews
            .Include(r => r.User)
            .Include(r => r.Book)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Review>> GetAllWithRelations()
    {
        return await _context.Reviews
            .Include(r => r.User)
            .Include(r => r.Book)
            .ToListAsync();
    }
}