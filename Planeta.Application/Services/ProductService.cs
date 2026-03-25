using Planeta.Application.DTOs.Catalog;
using Planeta.Application.Interfaces;
using Planeta.Domain.Interfaces;

namespace Planeta.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IEnumerable<ProductDto>> GetCatalogAsync(int? categoryId, int? brandId, bool? IsUsed)
    {
        var products = await _productRepository.GetAllAsync();

        var query = products.AsQueryable();

        if (categoryId.HasValue)
        {
            query = query.Where(product => product.CategoryId == categoryId);
        }

        if (brandId.HasValue)
        {
            query = query.Where(product => product.BrandId == brandId);
        }

        if (IsUsed.HasValue)
        {
            query = query.Where(product => product.IsUsed == IsUsed);
        }

        return query.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryName = product.Category.Name,
            Description = product.Description,
            BrandName = product.Brand.Name,
            IsUsed = product.IsUsed,
            MainImageUrl = product.Images.FirstOrDefault(i => i.IsMain).ImagePath ??
                           product.Images.FirstOrDefault().ImagePath

        }).ToList<ProductDto>();
    }

    public Task<ProductDto> GetByIdAsync(int productId)
    {
        throw new NotImplementedException();
    }
}