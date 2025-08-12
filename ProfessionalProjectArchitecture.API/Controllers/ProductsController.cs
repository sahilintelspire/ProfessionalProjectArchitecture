using Microsoft.AspNetCore.Mvc;
using ProfessionalProjectArchitecture.Core.DTOs;

namespace ProfessionalProjectArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            var products = new List<ProductDto>
            {
                new ProductDto { Name = "Laptop", Price = 999.99m },
                new ProductDto { Name = "Smartphone", Price = 499.49m }
            };

            return Ok(products);
        }
    }
}