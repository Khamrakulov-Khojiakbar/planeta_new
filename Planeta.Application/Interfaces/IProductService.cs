using Planeta.Application.DTOs.Catalog;

namespace Planeta.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetCatalogAsync(int? categoryId, int? brandId, bool? IsUsed);
    Task<ProductDto> GetByIdAsync(int productId);
}