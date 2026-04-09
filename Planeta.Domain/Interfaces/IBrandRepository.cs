using Planeta.Domain.Entities;

namespace Planeta.Domain.Interfaces;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllAsync();
    Task<Brand?> GetByIdAsync(int id);
    Task AddAsync(Brand brand);
    void Update(Brand brand);
    void Delete(Brand brand);
    
    Task SaveChangesAsync();
}