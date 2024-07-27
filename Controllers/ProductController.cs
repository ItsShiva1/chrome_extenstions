using chrome_extenstions.IServices;
using chrome_extenstions.Models;
using chrome_extenstions.Services;
using Microsoft.AspNetCore.Mvc;

namespace chrome_extenstions.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(FirebaseService firebaseService)
        {
            _productService = new ProductService(firebaseService);
        }
        [HttpGet("GetAllProducts")]
        public List<Product> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("GetProductById/{productId}")]
        public Product? GetProductById(string productId)
        {
            return _productService.GetProductById(productId);
        }

        [HttpPost("GetProductByMappedUrl")]
        public Product? GetProductByMappedUrl([FromBody] Product product)
        {
            if (product == null) return null;
            return _productService.GetProductByMappedUrls(product.MappedUrls);
        }

        [HttpPost("AddProducts")]
        public object? AddProducts([FromBody] List<Product> products)
        {
            return _productService.AddProducts(products);
        }

        /*[HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            product.Id = Guid.NewGuid();
            await _firebaseService.SetAsync($"products/{product.Id}", product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Product product)
        {
            await _firebaseService.SetAsync($"products/{id}", product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _firebaseService.DeleteAsync($"products/{id}");
            return NoContent();
        }*/
    }
}
