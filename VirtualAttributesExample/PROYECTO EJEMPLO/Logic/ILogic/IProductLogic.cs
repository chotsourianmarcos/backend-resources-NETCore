using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IProductLogic
    {
        void InsertProductItem(ProductItem productItem);
        public List<OrderItem> GetProductOrders(int id);
        public ProductItem GetProductById(int id);
    }
}
