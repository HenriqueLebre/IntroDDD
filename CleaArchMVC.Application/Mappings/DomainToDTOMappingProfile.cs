using AutoMapper;
using CleaArchMVC.Application.DTOs;
using CleaArchMVC.Domain.Entities;

namespace CleaArchMVC.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();

        }

    }
}
