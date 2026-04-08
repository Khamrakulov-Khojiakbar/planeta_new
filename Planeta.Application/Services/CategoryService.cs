using AutoMapper;
using Planeta.Application.DTOs.Catalog;
using Planeta.Application.Exceptions;
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
    
    public async Task<CategoryDto> GetByIdAsync(int categoryId)
    {
        var category = await _repository.GetCategoryByIdAsync(categoryId);
        
        return _mapper.Map<CategoryDto>(category);
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

    public async Task<CategoryDto> UpdateCategory(CategoryDto categoryDto)
    {
        var existingCategory = await _repository.GetCategoryByIdAsync(categoryDto.Id);
        
        if (existingCategory == null) return null;

        existingCategory.Name = categoryDto.Name;
        
        await _repository.SaveChangesAsync();
        
        return _mapper.Map<CategoryDto>(existingCategory);
    }

    public async Task DeleteCategory(int id)
    {
           var category =  await _repository.GetCategoryByIdAsync(id);

           if (category == null)
           {
               throw new CategoryNotFoundException(id);
           }
           
           _repository.DeleteAsync(category);
           await _repository.SaveChangesAsync();
    }
}