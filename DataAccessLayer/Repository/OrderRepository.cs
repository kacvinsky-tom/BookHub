﻿using DataAccessLayer.Entity;
using DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(BookHubDbContext context)
        : base(context) { }

    public override IQueryable<Order> GetBasicQuery()
    {
        return Context
            .Orders.Include(o => o.User)
            .Include(o => o.OrderItems)
            .Include(o => o.VoucherUsed);
    }

    public async Task<IEnumerable<Order>> GetAllWithRelations()
    {
        return await GetBasicQuery().ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetAllByUserId(int id)
    {
        return await Context.Orders.Where(o => o.User.Id == id).ToListAsync();
    }

    public async Task<Order?> GetByIdWithRelations(int id)
    {
        return await GetBasicQuery().FirstOrDefaultAsync(w => w.Id == id);
    }
}
