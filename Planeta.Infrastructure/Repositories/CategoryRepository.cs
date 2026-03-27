using Microsoft.EntityFrameworkCore;
using Planeta.Domain.Entities;
using Planeta.Domain.Interfaces;
using Planeta.Infrastructure.Persistence;

namespace Planeta.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly PlanetaDbContext _dbContext;

    public CategoryRepository(PlanetaDbContext  dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        
        return category;
    }

    public async Task<Category?> GetCategoryByNameAsync(string name)
    {
        var category =  await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);
        
        return category;
        
    }

    public Task AddAsync(Category category)
    {
        return Task.FromResult(_dbContext.Categories.Add(category));
    }

    public void UpdateAsync(Category category)
    {
        var oldCategory = _dbContext.Categories.FirstOrDefault(c => c.Id == category.Id);
        
        oldCategory.Name = category.Name;
        oldCategory.Products = category.Products;
        _dbContext.SaveChanges();

    }

    public void DeleteAsync(Category category)
    {
        var oldCategory = _dbContext.Categories.FirstOrDefault(c => c.Id == category.Id);
        
        _dbContext.Categories.Remove(oldCategory);
        _dbContext.SaveChanges();
    }

    public Task SaveChangesAsync()
    {
        _dbContext.SaveChangesAsync();
        return Task.CompletedTask;
    }
}