namespace BigDaddyBackend.Application.DTOs;

public record CartItemDto(int Id, string Name, int Quantity, decimal Price);