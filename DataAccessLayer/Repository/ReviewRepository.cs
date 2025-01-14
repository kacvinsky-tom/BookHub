﻿using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class ReviewRepository : GenericRepository<Review>, IReviewRepository
{
    public ReviewRepository(BookHubDbContext context)
        : base(context) { }

    public async Task<Review?> GetByIdWithRelations(int id)
    {
        return await Context
            .Reviews.Include(r => r.User)
            .Include(r => r.Book)
            .ThenInclude(b => b.Authors)
            .Include(r => r.Book)
            .ThenInclude(b => b.Genres)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<Review>> GetAllWithRelations()
    {
        return await Context.Reviews.Include(r => r.User).Include(r => r.Book).ToListAsync();
    }
}
