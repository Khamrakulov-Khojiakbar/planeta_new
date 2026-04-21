using Planeta.Application.DTOs.PhoneOptions;

namespace Planeta.Application.DTOs.Catalog;

public record CreateProductDto(
    string Name,
    string Description,
    decimal Price,
    int CategoryId,
    int? BrandId,
    bool IsUsed,
    string? Imei,
    PhoneOptionsDto? PhoneOptions,
    int StockQuantity,
    string mainImageUrl,
    List<string> ImageUrls);