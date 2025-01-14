﻿using Core.Helpers;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(BookHubDbContext context)
        : base(context) { }

    public override IQueryable<Book> GetBasicQuery()
    {
        return Context
            .Books.Include(book => book.BookGenres)
            .ThenInclude(bg => bg.Genre)
            .Include(book => book.Reviews)
            .ThenInclude(review => review.User)
            .Include(book => book.Publisher)
            .Include(book => book.BookAuthors)
            .Include(book => book.Authors)
            .Where(book => !book.IsDeleted);
    }

    public async Task<Book?> GetByIdWithRelations(int id)
    {
        return await GetBasicQuery().FirstOrDefaultAsync(book => book.Id == id);
    }

    public async Task<IEnumerable<SimpleListResult>> GetSimpleList(
        IEnumerable<Ordering<Book>>? order = null
    )
    {
        var query = Context.Books.AsQueryable();

        if (order != null)
        {
            query = ApplyOrderingExpressions(order, query);
        }

        return await query
            .Select(b => new SimpleListResult { Id = b.Id.ToString(), Value = b.Title })
            .ToListAsync();
    }
}
