using AutoMapper;
using Planeta.Application.DTOs.Catalog;
using Planeta.Application.Interfaces;
using Planeta.Domain.Entities;
using Planeta.Domain.Interfaces;

namespace Planeta.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
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

        
        
        /*return query.Select(product => new ProductDto
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

        }).ToList<ProductDto>();*/
        return _mapper.Map<IEnumerable<ProductDto>>(query.ToList());
        
    }

    public async Task<ProductDto> GetByIdAsync(int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        
        if (product == null) return null;
        
        return  _mapper.Map<ProductDto>(product);
    }

    public async Task UpdateProductAsync(int productId, ProductDto productDto)
    {
        var existingProduct = await _productRepository.GetProductWithImagesAsync(productId);
        if(existingProduct == null) return;
        
        
        _mapper.Map(productDto,  existingProduct);
        
        
        existingProduct.Images.Clear();

        foreach (var url in productDto.ImageUrls)
        {
            existingProduct.Images.Add(new ProductImage
            {
                ImagePath = url,
                IsMain = (url == productDto.MainImageUrl)
            });
        }
        
        await _productRepository.SaveChangesAsync();
        
    }


    public async Task<ProductDto> AddAsync(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);

        if (!string.IsNullOrEmpty(createProductDto.mainImageUrl))
        {
            product.Images.Add(new ProductImage
            {
                ImagePath =  createProductDto.mainImageUrl,
                IsMain = true
            });
        }

        if (createProductDto.ImageUrls != null)
        {
            foreach (var imageUrl in createProductDto.ImageUrls)
            {
                product.Images.Add(new ProductImage
                {
                    ImagePath = imageUrl,
                    IsMain = false
                });
            }
        }
        
        
        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();
        
        return _mapper.Map<ProductDto>(product);
    }

    public async Task DeleteAsync(int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        
        if (product == null)
            throw new KeyNotFoundException("Product not found");
        
        _productRepository.Delete(product);
        await _productRepository.SaveChangesAsync();
        
    }
}