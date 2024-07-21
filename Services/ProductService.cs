using chrome_extenstions.IServices;
using chrome_extenstions.Models;

namespace chrome_extenstions.Services
{
    public class ProductService : IProductService
    {
        private readonly FirebaseService _firebaseService;
        private readonly string entity = "Products";
        public ProductService(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        public List<Product> GetAllProducts()
        {
            return _firebaseService.Get<Product>(entity);
        }

        public Product? GetProductById(string productId)
        {
            var data = GetAllProducts();
            if(data != null) {
                return data.Where(x => x.Id.Equals(productId)).FirstOrDefault();
            }
            return default;

        }

        public Product? GetProductByMappedUrl(string productMappedUrl)
        {
            var data = GetAllProducts();
            if (data != null)
            {
                return data.Where(x => x.MappedUrl.Equals(productMappedUrl)).FirstOrDefault();
            }
            return default;
        }

        public object? AddProducts(List<Product> products)
        {
            if (products?.Any() != true) return default;
            object? result = null;
            foreach (var product in products)
            {
                result = _firebaseService.Push(entity, product);
            }
            return result;
        }
        public object? Push(Product product)
        {
            if (product == null) return default;
            return _firebaseService.Push(entity, product);
        }
        public object? Set(Product product)
        {
            if (product == null) return default;
            return _firebaseService.Set(entity, product);
        }
    }
}
