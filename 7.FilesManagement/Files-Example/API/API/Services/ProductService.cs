using API.IServices;
using API.Models;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly ServiceContext _serviceContext;
        public ProductService(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertProduct(ProductItem productItem)
        {
            _serviceContext.Products.Add(productItem);
            _serviceContext.SaveChanges();
            return productItem.Id;
        }
    }
}
