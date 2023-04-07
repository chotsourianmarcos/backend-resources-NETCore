using Entities.Entities;
using Entities.RequestModels;

namespace APIService.IServices
{
    public interface IOrderService
    {
        int InsertOrder(NewOrderRequest newOrderRequest);
        public decimal GetProductRawPrice(int id);
        ProductItem GetProductItem(int id);
    }
}
