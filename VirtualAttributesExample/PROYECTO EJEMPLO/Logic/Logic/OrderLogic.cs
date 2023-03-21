using Data;
using Entities.Entities;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
