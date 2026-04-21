using Microsoft.AspNetCore.Mvc;
using Planeta.Application.DTOs.Catalog;
using Planeta.Application.Interfaces;
using Planeta.Domain.Entities;

namespace Planeta_New.Controllers;


[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Route("/api/products")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllAsync(
        [FromQuery] int? categoryId,
        [FromQuery] int? brandId,
        [FromQuery] bool? isUsed)
    {
        var products = await _productService.GetCatalogAsync(categoryId, brandId, isUsed);
        return Ok(products);
        
    }


    [HttpGet]
    [Route("/api/products/{productId}")]
    public async Task<ActionResult<ProductDto>> GetByIdAsync(int productId) 
    {
        var product = await _productService.GetByIdAsync(productId);
        
        if (product == null)
        {
            return NotFound($"Product with id {productId} not found");
        }
        
        return Ok(product);
    }

    
    
    
    [HttpPost]
    [Route("/api/createproduct")]
    public async Task<ActionResult<ProductDto>> CreateAsync([FromBody] CreateProductDto createProductDto)
    {
        var result = await _productService.AddAsync(createProductDto);
        
        return Ok(result);
    }

    [HttpPut]
    [Route("api/updateproduct/{productId}")]
    public async Task<ActionResult<UpdateProductDto>> UpdateProduct(int productId, [FromBody] UpdateProductDto updateProductDto)
    {
        try
        {
            await _productService.UpdateProductAsync(productId, updateProductDto);

            return Ok(new { message = "Product is updated successfully" });
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
        
    }
    
}