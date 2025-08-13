using AutoMapper;
using ProfessionalProjectArchitecture.Core.DTOs;
using ProfessionalProjectArchitecture.Core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProfessionalProjectArchitecture.API.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
        }
    }
}
