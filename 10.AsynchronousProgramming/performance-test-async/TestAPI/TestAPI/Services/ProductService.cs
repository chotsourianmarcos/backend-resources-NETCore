using TestAPI.Data;
using TestAPI.IServices;
using TestAPI.Models;

namespace TestAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ServiceContext _serviceContext;
        public ProductService(ServiceContext serviceContext) {
            _serviceContext = serviceContext;
        }

        public void AddProducts(List<ProductItem> productList)
        {
            _serviceContext.Products.AddRange(productList);
            _serviceContext.SaveChanges();
        }

        public async Task AddProductsAsync(List<ProductItem> productList)
        {
            await _serviceContext.Products.AddRangeAsync(productList);
            await _serviceContext.SaveChangesAsync();
        }
    }
}
