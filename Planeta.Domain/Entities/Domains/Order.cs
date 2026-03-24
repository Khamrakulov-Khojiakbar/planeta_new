namespace Planeta.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public string UserName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Comment { get; set; } = string.Empty;

    public decimal TotalPrice { get; set; }
    public bool IsProcessed { get; set; }

    public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}