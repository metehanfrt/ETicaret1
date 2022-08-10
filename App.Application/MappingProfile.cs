using App.Application.Dtos;
using App.Infrastructure.Data.Entity;
using AutoMapper;

namespace App.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.CategoryName, s => s.MapFrom(t => t.Name))
                .ForMember(d => d.ParentCategoryName, s => s.MapFrom(t => t.ParentCategory.Name));

            CreateMap<CategoryDto, Category>().ForMember(d => d.Name, s => s.MapFrom(source => source.CategoryName));

            CreateMap<Product, ProductPriceDto>();
            CreateMap<UserDto, User>();
        }
    }
}
