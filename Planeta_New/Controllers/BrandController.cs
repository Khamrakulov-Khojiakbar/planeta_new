using Microsoft.AspNetCore.Mvc;
using Planeta.Application.DTOs.Brand;
using Planeta.Application.Interfaces;
using Planeta.Domain.Entities;

namespace Planeta_New.Controllers;


[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;
    
    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    [Route("/api/brands")]
    public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
    {
        var brands = await _brandService.GetBrandsAsync();
        return Ok(brands);
    }

    [HttpGet]
    [Route("/api/brand/{id}")]
    public async Task<ActionResult<BrandDto>> GetBrandById(int id)
    {
        var brand = await _brandService.GetBrandAsync(id);
        
        return Ok(brand);
    }
    
    
    
}