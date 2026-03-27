using AutoMapper;
using Planeta.Application.DTOs.Catalog;
using Planeta.Domain.Entities;

namespace Planeta.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src =>
                src.Images.FirstOrDefault(i => i.IsMain) != null ? src.Images.FirstOrDefault(i => i.IsMain)!.ImagePath
                : src.Images.FirstOrDefault() != null ? src.Images.FirstOrDefault()!.ImagePath : null))
            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.ImagePath)));

        CreateMap<CreateProductDto, Product>();
        
        CreateMap<CategoryDto, Category>();
        CreateMap<CreateCategoryDto, Category>();


    }
}