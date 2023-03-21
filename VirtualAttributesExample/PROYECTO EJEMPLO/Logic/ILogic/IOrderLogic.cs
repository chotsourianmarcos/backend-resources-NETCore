using Entities.Entities;

namespace Logic.ILogic
{
    public interface IOrderLogic
    {
        void InsertOrderItem(OrderItem orderItem);
        public decimal GetProductRawPrice(int id);
        ProductItem GetProductItem(int id);
    }
}
