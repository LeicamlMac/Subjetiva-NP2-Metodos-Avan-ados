using BigDaddyBackend.Domain.Entities;
using BigDaddyBackend.Domain.Interfaces;
using BigDaddyBackend.Infrastructure.Data;

namespace BigDaddyBackend.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context) => _context = context;

    public async Task<Order> CreateAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }
}