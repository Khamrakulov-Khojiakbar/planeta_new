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
            .FirstOrDefaultAsync(p => p.Id == id);
        
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
    }

    public void Update(Product product)
    {
        throw new NotImplementedException();
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