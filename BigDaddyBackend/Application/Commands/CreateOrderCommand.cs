using MediatR;
using BigDaddyBackend.Application.DTOs;

namespace BigDaddyBackend.Application.Commands;

public record CreateOrderCommand(
    int TableNumber,
    string Observations,
    List<CartItemDto> Items
) : IRequest<int>;