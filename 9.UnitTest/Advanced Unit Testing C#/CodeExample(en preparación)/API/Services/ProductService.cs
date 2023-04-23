using API.Data;
using API.IServices;
using API.Models.Entities;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly ServiceContext _serviceContext;

        public ProductService(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public void DeactivateProduct(int productId)
        {
            var productItem = _serviceContext.Products.Where(o => o.Id == productId).First();
            if (productItem.IsActive)
            {
                productItem.IsActive = false;
                _serviceContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public ProductItem GetProductById(int productId)
        {
            return _serviceContext.Products.Where(o => o.Id == productId).First();
        }

        public List<ProductItem> GetProducts()
        {
            return _serviceContext.Products.ToList();
        }

        public int InsertProduct(ProductItem productItem)
        {
            _serviceContext.Products.Add(productItem);
            _serviceContext.SaveChanges();
            return productItem.Id;
        }

        public void UpdateProduct(ProductItem productItem)
        {
            _serviceContext.Products.Update(productItem);
            _serviceContext.SaveChanges();
        }
    }
}