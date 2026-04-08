namespace Planeta.Application.DTOs.Catalog;

public record CreateProductDto(
    string Name,
    string Description,
    decimal Price,
    int CategoryId,
    int? BrandId,
    bool IsUsed,
    string? Imei,
    Domain.Entities.PhoneOptions? PhoneOptions,
    int StockQuantity,
    string mainImageUrl,
    List<string> ImageUrls);