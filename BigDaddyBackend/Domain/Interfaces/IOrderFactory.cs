using BigDaddyBackend.Domain.Entities;
using BigDaddyBackend.Application.DTOs;

namespace BigDaddyBackend.Domain.Interfaces;

public interface IOrderFactory
{
    Order CreateOrder(int tableNumber, string observations, List<CartItemDto> items);
}