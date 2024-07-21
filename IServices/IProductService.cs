using chrome_extenstions.Models;

namespace chrome_extenstions.IServices
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetProductByMappedUrl(string productMappedUrl);
        Product? GetProductById(string productId);
        object? AddProducts(List<Product> products);
        object? Push(Product product);
        object? Set(Product product);
    }
}
