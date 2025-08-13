using AutoMapper;
using ProfessionalProjectArchitecture.Core.DTOs;
using ProfessionalProjectArchitecture.Core.Interfaces;
using ProfessionalProjectArchitecture.Core.Models; // Product entity

namespace ProfessionalProjectArchitecture.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private static readonly List<Product> _products = new();

        public ProductService(IMapper mapper) => _mapper = mapper;

        public Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(_products);
            return Task.FromResult(dtos);
        }

        public Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var entity = _products.FirstOrDefault(p => p.Id == id);
            var dto = entity is null ? null : _mapper.Map<ProductDto>(entity);
            return Task.FromResult(dto);
        }

        public Task<ProductDto> CreateProductAsync(CreateProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            entity.Id = _products.Count + 1;
            _products.Add(entity);
            var created = _mapper.Map<ProductDto>(entity);
            return Task.FromResult(created);
        }
    }
}
