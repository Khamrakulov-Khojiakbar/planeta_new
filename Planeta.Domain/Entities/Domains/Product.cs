namespace Planeta.Domain.Entities;

public class Product
{
    public int  Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    
    // for phones
    public bool IsUsed { get; set; }
    public string IMEI { get; set; }

    public int? BrandId { get; set; }
    public virtual Brand? Brand { get; set; }

    public int  CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
}