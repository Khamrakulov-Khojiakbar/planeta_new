using AutoMapper;
using Planeta.Application.DTOs.Catalog;
using Planeta.Application.Interfaces;
using Planeta.Domain.Entities;
using Planeta.Domain.Interfaces;

namespace Planeta.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository  _repository;
    private readonly IMapper _mapper;


    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public Task<CategoryDto> GetByIdAsync(int categoryId)
    {
        var category = _repository.GetCategoryByIdAsync(categoryId);
        
        return Task.FromResult(_mapper.Map<CategoryDto>(category));
    }

    public async Task<List<CategoryDto>> GetCategoriesAsync()
    {
        var categroies = await _repository.GetCategoriesAsync();
        return _mapper.Map<List<CategoryDto>>(categroies);
    }

    public async Task<CategoryDto> AddCategory(CreateCategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _repository.AddAsync(category);
        await _repository.SaveChangesAsync();
        
        return _mapper.Map<CategoryDto>(category);
    }

    public Task<CategoryDto> UpdateCategory(CategoryDto categoryDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteCategory(CategoryDto categoryDto)
    {
        throw new NotImplementedException();
    }
}