namespace Planeta.Domain.Entities;

public class ProductImage
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public bool IsMain { get; set; }

    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}