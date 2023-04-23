using API.Data;
using API.IServices;
using API.Models.Entities;

namespace API.Services
{
    public class OrderService : IOrderService
    {
        private readonly ServiceContext _serviceContext;
        private readonly IEmailService _emailService;

        public OrderService(ServiceContext serviceContext, IEmailService emailService) {
            _serviceContext = serviceContext;
            _emailService = emailService;
        }

        public void DeactivateOrder(int orderId)
        {
            var orderItem = _serviceContext.Orders.Where(o => o.Id == orderId).First();
            if (orderItem.IsActive)
            {
                orderItem.IsActive = false;
                _serviceContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public OrderItem GetOrderById(int orderId)
        {
            return _serviceContext.Orders.Where(o => o.Id == orderId).First();
        }

        public List<OrderItem> GetOrders()
        {
            return _serviceContext.Orders.ToList();
        }

        public int InsertOrder(OrderItem orderItem)
        {
            _serviceContext.Orders.Add(orderItem);
            _serviceContext.SaveChanges();
            _emailService.SendNewOrderNotification(orderItem);
            return orderItem.Id;
        }

        public void UpdateOrder(OrderItem orderItem)
        {
            _serviceContext.Orders.Update(orderItem);
            _serviceContext.SaveChanges();
        }
    }
}