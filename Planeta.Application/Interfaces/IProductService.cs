using Planeta.Application.DTOs.Catalog;
using Planeta.Domain.Entities;

namespace Planeta.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetCatalogAsync(int? categoryId, int? brandId, bool? IsUsed);
    Task<ProductDto> GetByIdAsync(int productId);
    
    Task UpdateProductAsync(int productId, UpdateProductDto productDto);
    
    Task<ProductDto> AddAsync(CreateProductDto createProductDto);
    
    Task DeleteAsync(int productId);
}