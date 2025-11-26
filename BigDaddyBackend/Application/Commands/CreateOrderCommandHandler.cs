using MediatR;
using BigDaddyBackend.Domain.Entities;
using BigDaddyBackend.Domain.Interfaces;
using BigDaddyBackend.Application.Services;

namespace BigDaddyBackend.Application.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _repository;
    private readonly IOrderFactory _factory;

    public CreateOrderCommandHandler(IOrderRepository repository, IOrderFactory factory)
    {
        _repository = repository;
        _factory = factory;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken ct)
    {
        var order = _factory.CreateOrder(request.TableNumber, request.Observations, request.Items);
        var created = await _repository.CreateAsync(order);
        return created.Id;
    }
}