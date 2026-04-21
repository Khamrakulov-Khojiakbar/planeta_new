using Planeta.Application.DTOs.PhoneOptions;

namespace Planeta.Application.DTOs.Catalog;

public record UpdateProductDto
(
    int Id,                        // ID обязателен, чтобы сверить его с маршрутом
    string Name,
    string Description,
    decimal Price,
    int CategoryId,
    int? BrandId,
    bool IsUsed,
    string? Imei,                  // Может быть null для аксессуаров
    int StockQuantity,
    PhoneOptionsDto? PhoneOptions, // DTO опций памяти/аккумулятора
    string? MainImageUrl,
    List<string> ImageUrls    
    );