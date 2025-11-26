using BigDaddyBackend.Domain.Entities;
using BigDaddyBackend.Domain.Interfaces;
using BigDaddyBackend.Application.DTOs;

namespace BigDaddyBackend.Application.Services;

public class OrderFactory : IOrderFactory
{
    public Order CreateOrder(int tableNumber, string observations, List<CartItemDto> items)
    {
        var order = new Order
        {
            TableNumber = tableNumber,
            Observations = observations,
            Total = items.Sum(i => i.Price * i.Quantity)
        };

        foreach (var item in items)
        {
            order.Items.Add(new OrderItem
            {
                Name = item.Name,
                Quantity = item.Quantity,
                Price = item.Price
            });
        }

        return order;
    }
}