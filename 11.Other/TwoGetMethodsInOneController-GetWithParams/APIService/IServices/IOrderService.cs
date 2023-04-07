using Entities.Entities;

namespace APIService.IServices
{
    public interface IOrderService
    {
        int InsertOrder(OrderItem orderItem);
    }
}
