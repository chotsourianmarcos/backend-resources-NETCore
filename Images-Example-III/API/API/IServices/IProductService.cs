using API.Models;

namespace API.IServices
{
    public interface IProductService
    {
        int InsertProduct(ProductItem productItem);
        List<ProductItem> GetAllProducts();
    }
}
