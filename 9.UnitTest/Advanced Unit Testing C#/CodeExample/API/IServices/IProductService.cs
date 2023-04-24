using API.Models.Entities;

namespace API.IServices
{
    public interface IProductService
    {
        int InsertProduct(ProductItem productItem);
        void UpdateProduct(ProductItem productItem);
        List<ProductItem> GetProducts();
        ProductItem GetProductById(int productId);
        void DeactivateProduct(int productId);
    }
}
