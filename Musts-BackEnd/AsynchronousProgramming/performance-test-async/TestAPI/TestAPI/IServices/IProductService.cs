using TestAPI.Models;

namespace TestAPI.IServices
{
    public interface IProductService
    {
        Task AddProductsAsync(List<ProductItem> productList);
        void AddProducts(List<ProductItem> productList);
    }
}