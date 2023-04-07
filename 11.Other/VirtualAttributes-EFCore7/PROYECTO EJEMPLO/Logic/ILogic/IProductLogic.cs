using Entities.Entities;

namespace Logic.ILogic
{
    public interface IProductLogic
    {
        void InsertProductItem(ProductItem productItem);
        public List<OrderItem> GetProductOrders(int id);
        public ProductItem GetProductById(int id);
    }
}
