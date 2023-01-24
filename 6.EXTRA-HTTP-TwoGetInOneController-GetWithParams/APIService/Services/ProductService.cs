using APIService.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;

namespace APIService.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductLogic _productLogic;
        public ProductService(IProductLogic productLogic) {
            _productLogic = productLogic;
        }
        public int InsertProduct(ProductItem productItem)
        {
            _productLogic.InsertProductItem(productItem);
            return productItem.Id;
        }
        public List<ProductItem> GetAllProducts()
        {
            return _productLogic.GetAllProducts();
        }
        public List<ProductItem> GetProductsByCriteria(ProductFilter productFilter)
        {
            return _productLogic.GetProductsByCriteria(productFilter);
        }
    }
}
