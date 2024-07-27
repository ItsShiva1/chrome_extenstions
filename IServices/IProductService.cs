using chrome_extenstions.Models;

namespace chrome_extenstions.IServices
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetProductByMappedUrls(List<string> productMappedUrls);
        Product? GetProductById(string productId);
        object? AddProducts(List<Product> products);
        object? Push(Product product);
        object? Set(Product product);
    }
}
