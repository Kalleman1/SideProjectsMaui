using Microsoft.AspNetCore.Mvc;
using WebAPIDummy.Models;

namespace WebAPIDummy.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = new List<Product>
            {
                new Product { Name = "Product 1", Description = "Description 1", Price = 10.0, Amount = 100 },
                new Product { Name = "Product 2", Description = "Description 2", Price = 20.0, Amount = 200 },
                new Product { Name = "Product 3", Description = "Description 3", Price = 30.0, Amount = 300 }
            };

            return products;
        }
    }
}

