using Planeta.Application.DTOs.PhoneOptions;

namespace Planeta.Application.DTOs.Catalog;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string? BrandName { get; set; }
    public string? StorageInfo { get; set; }
    public bool IsUsed { get; set; }

    public string? MainImageUrl { get; set; }
    
    public PhoneOptionsDto? PhoneOptions { get; set; }
    
    public List<string> ImageUrls { get; set; } = new();
}