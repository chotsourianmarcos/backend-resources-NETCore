using API.Models.Entities;

namespace API.IServices
{
    public interface IOrderService
    {
        int InsertOrder(OrderItem orderItem);
        void UpdateOrder(OrderItem orderItem);
        List<OrderItem> GetOrders();
        OrderItem GetOrderById(int orderId);
        void DeactivateOrder(int orderId);
    }
}
