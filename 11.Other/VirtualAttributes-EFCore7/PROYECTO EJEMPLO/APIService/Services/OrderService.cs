using APIService.IServices;
using Entities.Entities;
using Entities.RequestModels;
using Logic.ILogic;

namespace APIService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderLogic _orderLogic;
        private readonly IProductLogic _productLogic;
        public OrderService(IOrderLogic orderLogic, IProductLogic productLogic)
        {
            _orderLogic = orderLogic;
            _productLogic = productLogic;
        }
        public int InsertOrder(NewOrderRequest newOrderRequest)
        {
            var orderItem = ToOrderItem(newOrderRequest);
            _orderLogic.InsertOrderItem(orderItem);
            return orderItem.Id;
        }
        public decimal GetProductRawPrice(int id)
        {
            return _orderLogic.GetProductRawPrice(id);
        }
        public ProductItem GetProductItem(int id)
        {
            return _orderLogic.GetProductItem(id);
        }
        public OrderItem ToOrderItem(NewOrderRequest newOrderRequest)
        {
            var orderItem = new OrderItem();
            orderItem.IdWeb = Guid.NewGuid();
            orderItem.IdProduct = newOrderRequest.IdProduct;
            orderItem.Amount = newOrderRequest.Amount;
            orderItem.OrderDate = newOrderRequest.OrderDate;
            orderItem.DeliveryDate = newOrderRequest.DeliveryDate;
            orderItem.Product = _productLogic.GetProductById(orderItem.IdProduct);
            return orderItem;
        }
    }
}
