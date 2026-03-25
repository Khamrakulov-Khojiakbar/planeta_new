using AutoMapper;
using Planeta.Application.DTOs.Catalog;
using Planeta.Domain.Entities;

namespace Planeta.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //CreateMap<Product, ProductDto>().ForMember(dest = dest.CategoryName, opt => opt.MapFrom(src => src.Category));
    }
}