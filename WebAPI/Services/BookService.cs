﻿using DataAccessLayer;
using DataAccessLayer.Entity;
using DataAccessLayer.Exception;
using WebAPI.InputType;

namespace WebAPI.Services;

public class BookService
{
    private readonly UnitOfWork _unitOfWork;

    public BookService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Book> Create(BookInput bookCreateInput)
    {
        var publisher = await _unitOfWork.Publishers.GetById(bookCreateInput.PublisherId);
        var authors = await _unitOfWork.Authors
            .Find(author => bookCreateInput.AuthorsIds.Contains(author.Id));

        if (authors == null)
        {
            throw new EntityNotFoundException<Author>(bookCreateInput.AuthorsIds.FirstOrDefault());
        }
        if (publisher == null)
        {
            throw new EntityNotFoundException<Publisher>(bookCreateInput.PublisherId);
        }
        
        var genres = await _unitOfWork.Genres
            .Find(genre => bookCreateInput.GenreIds.Contains(genre.Id));

        var book = new Book
        {
            Title = bookCreateInput.Title,
            ISBN = bookCreateInput.ISBN,
            Description = bookCreateInput.Description,
            Image = bookCreateInput.Image,
            Price = bookCreateInput.Price,
            Quantity = bookCreateInput.Quantity,
            PublisherId = bookCreateInput.PublisherId,
            ReleaseYear = bookCreateInput.ReleaseYear,
            IsDeleted = false,
            Authors = authors.ToList(),
            Genres = genres.ToList(),
        };

        return book;
    }

    public async Task Update(BookInput bookUpdateInput, Book book)
    {
        var publisher = await _unitOfWork.Publishers.GetById(bookUpdateInput.PublisherId);
        
        if (publisher == null)
        {
            throw new EntityNotFoundException<Publisher>(bookUpdateInput.PublisherId);
        }
        
        var authors = await _unitOfWork.Authors
            .Find(author => bookUpdateInput.AuthorsIds.Contains(author.Id));

        if (authors == null)
        {
            throw new EntityNotFoundException<Author>(bookUpdateInput.AuthorsIds.FirstOrDefault());
        }
        if (publisher == null)
        {
            throw new EntityNotFoundException<Publisher>(bookUpdateInput.PublisherId);
        }
        
        var genres = await _unitOfWork.Genres
            .Find(genre => bookUpdateInput.GenreIds.Contains(genre.Id));

        book.Title = bookUpdateInput.Title;
        book.ISBN = bookUpdateInput.ISBN;
        book.Description = bookUpdateInput.Description;
        book.Image = bookUpdateInput.Image;
        book.Price = bookUpdateInput.Price;
        book.Quantity = bookUpdateInput.Quantity;
        book.PublisherId = bookUpdateInput.PublisherId;
        book.ReleaseYear = bookUpdateInput.ReleaseYear;
        book.IsDeleted = bookUpdateInput.IsDeleted;
        book.Authors = authors.ToList();
        book.Genres = genres.ToList();
    }
    public void Delete(Book book)
    {
        book.IsDeleted = true;
    }

}