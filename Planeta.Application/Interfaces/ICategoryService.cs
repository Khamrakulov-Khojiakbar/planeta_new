using Planeta.Application.DTOs.Catalog;

namespace Planeta.Application.Interfaces;

public interface ICategoryService
{
    Task<CategoryDto> GetByIdAsync(int categoryId);
}