using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.ProductsCQRS.Commands;

namespace CleanArchMvc.Application.Mappings
{
    public class DTOToCommand : Profile
    {
        public DTOToCommand()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
