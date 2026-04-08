using Microsoft.AspNetCore.Mvc;
using Planeta.Application.DTOs.Catalog;
using Planeta.Application.Interfaces;

namespace Planeta_New.Controllers;


[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService  _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpPost]
    [Route("/api/createcategory")]
    public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody]  CreateCategoryDto category)
    {
        var result = await _categoryService.AddCategory(category);
        return Ok(result);
    }

    [HttpGet]
    [Route("/api/getcategories")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        var categories =  await _categoryService.GetCategoriesAsync();
        return Ok(categories);
    }

    [HttpDelete]
    [Route("/api/deletecategory/{id}")]
    public async Task<ActionResult<CategoryDto>> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategory(id);
        return NoContent();
    }
    
    
}