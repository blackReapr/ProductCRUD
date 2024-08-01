using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new()
        {
            new() { Id=1, Name = "Product-1", Price = 20},
            new() { Id=2, Name = "Product-2", Price = 30},
            new() { Id=3, Name = "Product-3", Price = 40},
            new() { Id=4, Name = "Product-4", Price = 50},
            new() { Id=5, Name = "Product-5", Price = 60},
            new() { Id=6, Name = "Product-6", Price = 70},
        };

        [HttpGet]
        public IActionResult Get() => Ok(_products);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product? product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(CreateProductDto product)
        {
            _products.Add(new() { Id=_products[_products.Count - 1].Id + 1, Name = product.Name, Price = product.Price });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product? product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            _products.Remove(product);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(UpdateProductDto productDto, int id)
        {
            Product? product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            product.Name = productDto.Name;
            product.Price = productDto.Price;
            return Ok(product);
        }
    }
}
