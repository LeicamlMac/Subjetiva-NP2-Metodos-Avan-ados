using Microsoft.AspNetCore.Mvc;
using MediatR;
using BigDaddyBackend.Application.Commands;
using BigDaddyBackend.Application.DTOs;

namespace BigDaddyBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
    {
        var command = new CreateOrderCommand(
            request.TableNumber,
            request.Observations ?? "",
            request.Items.Select(i => new CartItemDto(i.Id, i.Name, i.Quantity, i.Price)).ToList()
        );

        var orderId = await _mediator.Send(command);
        return Ok(new { Message = "Pedido enviado com sucesso!", OrderId = orderId });
    }
}

public record CreateOrderRequest(int TableNumber, string? Observations, List<CartItemRequest> Items);
public record CartItemRequest(int Id, string Name, int Quantity, decimal Price);