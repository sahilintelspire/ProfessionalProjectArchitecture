using System.Collections.Generic;
using System.Threading.Tasks;
using ProfessionalProjectArchitecture.Core.DTOs;

namespace ProfessionalProjectArchitecture.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> CreateProductAsync(CreateProductDto dto);
    }
}
