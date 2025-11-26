using BigDaddyBackend.Domain.Entities;

namespace BigDaddyBackend.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order> CreateAsync(Order order);
}