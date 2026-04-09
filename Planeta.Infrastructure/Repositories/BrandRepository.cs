using Microsoft.EntityFrameworkCore;
using Planeta.Domain.Entities;
using Planeta.Domain.Interfaces;
using Planeta.Infrastructure.Persistence;

namespace Planeta.Infrastructure.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly PlanetaDbContext _dbContext;


    public BrandRepository(PlanetaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Brand>> GetAllAsync()
    {
        return await _dbContext.Brands.ToListAsync();
    }

    public async Task<Brand?> GetByIdAsync(int id)
    {
        var brand = await _dbContext.Brands.FindAsync(id);
        
        return brand;
        
    }

    public async Task AddAsync(Brand brand)
    {
        await _dbContext.Brands.AddAsync(brand);
    }

    public void Update(Brand brand)
    {
        _dbContext.Brands.Update(brand);
    }

    public void Delete(Brand brand)
    {
        _dbContext.Brands.Remove(brand);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}