namespace BigDaddyBackend.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public string? Observations { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<OrderItem> Items { get; set; } = new();
}

public class OrderItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int OrderId { get; set; }
}