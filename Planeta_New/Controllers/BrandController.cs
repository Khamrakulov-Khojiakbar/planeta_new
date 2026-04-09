using Microsoft.AspNetCore.Mvc;
using Planeta.Application.DTOs.Brand;
using Planeta.Application.Exceptions;
using Planeta.Application.Interfaces;

namespace Planeta_New.Controllers;


[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;
    
    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpPost]
    [Route("/api/createbrand")]
    public async Task<ActionResult<CreateBrandDto>> CreateBrand([FromBody]CreateBrandDto brand)
    {
        var createdBrand = await _brandService.CreateBrandAsync(brand);

        return Ok(createdBrand);
    }

    [HttpPut]
    [Route("/api/updatebrand/{id}")]
    public async Task<ActionResult<BrandDto>> UpdateBrand(int id, [FromBody] CreateBrandDto brand)
    {
        try
        {
            await _brandService.UpdateBrandAsync(id, brand);
            return Ok(new {message = "Brand updated successfully"});
        }
        catch (Exception e)
        {
            throw new BrandNotFoundException(e.Message);
        }
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

    [HttpDelete]
    [Route("/api/brand/{id}")]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        if (id == 0)
        {
            throw new BrandNotFoundException(id);
        }
        await _brandService.DeleteBrandAsync(id);
        
        
        return NoContent();
    }
    
    
    
}