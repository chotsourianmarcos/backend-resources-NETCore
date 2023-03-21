using Data;
using Entities.Entities;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;

namespace Logic.Logic
{
    public class ProductLogic : IProductLogic
    {
        private readonly ServiceContext _serviceContext;
        public ProductLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public void InsertProductItem(ProductItem productItem)
        {
            _serviceContext.Products.Add(productItem);
            _serviceContext.SaveChanges();
        }
        public List<OrderItem> GetProductOrders(int id)
        {
            var productItem = _serviceContext.Set<ProductItem>()
                .Include(p => p.Orders)
                .Where(p => p.Id == id).FirstOrDefault();
            var orderCollection = productItem.Orders;
            return orderCollection.ToList();
        }
        public ProductItem GetProductById(int id)
        {
            var productItem = _serviceContext.Set<ProductItem>().Where(p => p.Id == id).FirstOrDefault();
            return productItem;
        }
    }
}
