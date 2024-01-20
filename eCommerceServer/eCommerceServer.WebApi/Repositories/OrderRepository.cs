﻿using ECommerceServer.WebApi.Context;
using ECommerceServer.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceServer.WebApi.Repositories;

public class OrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> GetAllByUserId(Guid userId)
    {
        return _context.Orders
            .Where(o => o.UserId == userId)
            .Include(p => p.Details)!
            .ThenInclude(p => p.Product)
            .OrderByDescending(p => p.Id)
            .ToList();
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }
}
