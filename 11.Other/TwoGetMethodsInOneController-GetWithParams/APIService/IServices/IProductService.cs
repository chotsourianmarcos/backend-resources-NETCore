using Entities.Entities;
using Entities.SearchFilters;

namespace APIService.IServices
{
    public interface IProductService
    {
        List<ProductItem> GetAllProducts();
        List<ProductItem> GetProductsByCriteria(ProductFilter productFilter);
        int InsertProduct(ProductItem productItem);
    }
}
