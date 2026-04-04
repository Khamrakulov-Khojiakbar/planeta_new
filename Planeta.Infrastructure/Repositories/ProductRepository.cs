using Microsoft.EntityFrameworkCore;
using Planeta.Domain.Entities;
using Planeta.Domain.Interfaces;
using Planeta.Infrastructure.Persistence;

namespace Planeta.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly PlanetaDbContext _dbContext;

    public ProductRepository(PlanetaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public Task<Product?> GetByIdAsync(int id)
    {
        var product = _dbContext.Products
            .Include(p => p.Images)
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Include(p => p.PhoneOptions)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _dbContext.Products
            .Include(p => p.Category) // Чтобы было имя категории
            .Include(p => p.Brand)    // Чтобы был бренд
            .Include(p => p.Images)   // Чтобы были фото
            .Include(p => p.PhoneOptions)
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
    }

    public void Update(Product product)
    {
        var exsistProduct = _dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
        if (exsistProduct != null)
        {
            
        }
    }

    public void Delete(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}