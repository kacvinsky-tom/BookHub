﻿using DataAccessLayer.Entity;

namespace DataAccessLayer.Repository.Interfaces;

public interface IBookRepository : IGenericRepository<Book>
{
    public Task<Book?> GetByIdWithRelations(int id);
}
