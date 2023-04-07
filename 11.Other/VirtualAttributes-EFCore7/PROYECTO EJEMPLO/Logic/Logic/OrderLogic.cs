using Data;
using Entities.Entities;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;

namespace Logic.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly ServiceContext _serviceContext;
        public OrderLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public void InsertOrderItem(OrderItem orderItem)
        {
            _serviceContext.Orders.Add(orderItem);
            _serviceContext.SaveChanges();
        }
        public decimal GetProductRawPrice(int id)
        {
            var orderItem = _serviceContext.Set<OrderItem>()
                .Include(x => x.Product)
                .Where(o => o.Id == id).FirstOrDefault();
            return orderItem.Product.RawPrice;
        }
        public ProductItem GetProductItem(int id)
        {
            var orderItem = _serviceContext.Set<OrderItem>()
                .Include(x => x.Product)
                .Where(o => o.Id == id).FirstOrDefault();
            return orderItem.Product;
        }
    }
}
