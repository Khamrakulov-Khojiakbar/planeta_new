using Planeta.Application.DTOs.Catalog;

namespace Planeta.Application.Interfaces;

public interface ICategoryService
{
    Task<CategoryDto> GetByIdAsync(int categoryId);
    Task<List<CategoryDto>> GetCategoriesAsync();
    
    Task<CategoryDto> AddCategory(CreateCategoryDto categoryDto);
    Task<CategoryDto> UpdateCategory(CategoryDto categoryDto);
    Task DeleteCategory(int id);
    
    
}