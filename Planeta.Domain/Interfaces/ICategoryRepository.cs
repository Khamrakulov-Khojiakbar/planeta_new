using Planeta.Domain.Entities;

namespace Planeta.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category?> GetCategoryByNameAsync(string name);
    Task AddAsync(Category category);
    void UpdateAsync(Category category);
    void DeleteAsync(Category category);
    Task SaveChangesAsync();
}