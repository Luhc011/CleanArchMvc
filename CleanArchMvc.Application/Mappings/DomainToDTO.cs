using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
