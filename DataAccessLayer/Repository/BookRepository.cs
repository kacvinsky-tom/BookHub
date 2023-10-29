﻿using DataAccessLayer.Entity;
using DataAccessLayer.Filter;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(BookHubDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Book>> GetWithRelations(BookFilter filterInput)
    {
        var query = _context.Books
            .Include(book => book.Genres)
            .Include(book => book.Reviews)
            .ThenInclude(review => review.User)
            .Include(book => book.Publisher)
            .Include(book => book.Authors)
            .Where(book => !book.IsDeleted);

        if (filterInput.Title != null)
        {
            query = query.Where(book => book.Title.ToLower().Contains(filterInput.Title.ToLower()));
        }

        if (filterInput.Description != null)
        {
            query = query.Where(book => book.Description.ToLower().Contains(filterInput.Description.ToLower()));
        }

        if (filterInput.PriceFrom != null)
        {
            query = query.Where(book => book.Price >= filterInput.PriceFrom);
        }

        if (filterInput.PriceTo != null)
        {
            query = query.Where(book => book.Price <= filterInput.PriceTo);
        }

        if (filterInput.GenreIds != null)
        {
            query = query.Where(book => book.Genres.Any(genre => filterInput.GenreIds.Contains(genre.Id)));
        }

        if (filterInput.AuthorName != null)
        {
            query = query.Where(
                book =>
                    book.Authors.Any(afn=> afn.FirstName.ToLower().Contains(filterInput.AuthorName.ToLower()) ||
                    book.Authors.Any(aln=> aln.LastName.ToLower().Contains(filterInput.AuthorName.ToLower()))
            ));
        }
        if (filterInput.PublisherName != null)
        {
            query = query.Where(
                book =>
                    book.Publisher.Name.ToLower().Contains(filterInput.PublisherName.ToLower())
            );
        }

        return await query.ToListAsync();
    }

    public async Task<Book?> GetByIdWithRelations(int id)
    {
        return await _context.Books
            .Include(book => book.Genres)
            .Include(book => book.Reviews)
            .ThenInclude(review => review.User)
            .Include(book => book.Publisher)
            .Include(book => book.Authors)
            .Where(book => !book.IsDeleted)
            .FirstOrDefaultAsync(book => book.Id == id);
    }
}