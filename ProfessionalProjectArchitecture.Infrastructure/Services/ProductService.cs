using AutoMapper;
using Microsoft.Extensions.Logging;
using ProfessionalProjectArchitecture.Core.DTOs;
using ProfessionalProjectArchitecture.Core.Interfaces;
using ProfessionalProjectArchitecture.Core.Models;

namespace ProfessionalProjectArchitecture.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        private static readonly List<Product> _products = new();

        public ProductService(IMapper mapper, ILogger<ProductService> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            _logger.LogInformation("Fetching all products. Total count: {Count}", _products.Count);

            var dtos = _mapper.Map<IEnumerable<ProductDto>>(_products);
            return Task.FromResult(dtos);
        }

        public Task<ProductDto?> GetProductByIdAsync(int id)
        {
            _logger.LogInformation("Fetching product by Id: {Id}", id);

            // Force exception for testing Global Error Handling
            if (id < 0)
            {
                _logger.LogError("Negative Id detected: {Id}. Throwing test exception.", id);
                throw new Exception("Test exception for global error handling and Serilog logging.");
            }

            var entity = _products.FirstOrDefault(p => p.Id == id);

            if (entity == null)
            {
                _logger.LogWarning("Product with Id {Id} not found.", id);
                return Task.FromResult<ProductDto?>(null);
            }

            var dto = _mapper.Map<ProductDto>(entity);
            return Task.FromResult<ProductDto?>(dto);
        }

        public Task<ProductDto> CreateProductAsync(CreateProductDto dto)
        {
            _logger.LogInformation("Creating a new product with Name: {Name}", dto.Name);

            var entity = _mapper.Map<Product>(dto);
            entity.Id = _products.Count + 1;
            _products.Add(entity);

            var created = _mapper.Map<ProductDto>(entity);

            _logger.LogInformation("Product created successfully with Id: {Id}", created.Id);

            return Task.FromResult(created);
        }
    }
}
