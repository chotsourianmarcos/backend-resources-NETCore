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
            if (!ValidateOrder(orderItem))
            {
                throw new InvalidDataException("La orden no es válida.");
            }
            _serviceContext.Orders.Add(orderItem);
            _serviceContext.SaveChanges();
            if (!ValidateInsertedOrder(orderItem))
            {
                throw new InvalidDataException("Se ha insertado un registro inconsistente.");
            }
            _emailService.SendNewOrderNotification(orderItem);
            return orderItem.Id;
        }

        public void UpdateOrder(OrderItem orderItem)
        {
            _serviceContext.Orders.Update(orderItem);
            _serviceContext.SaveChanges();
        }

        public bool ValidateOrder(OrderItem orderItem)
        {
            if (orderItem.IdBuyer < 1)
            {
                return false;
            }
            if (orderItem.IdProduct < 1)
            {
                return false;
            }
            if (orderItem.ProductAmount < 1)
            {
                return false;
            }
            if (orderItem.TotalPrice < 0)
            {
                return false;
            }
            if (orderItem.InsertDate > DateTime.Now)
            {
                return false;
            }
            if (orderItem.UpdateDate < orderItem.InsertDate)
            {
                return false;
            }
            return true;
        }

        public bool ValidateInsertedOrder(OrderItem orderItem)
        {
            if (!ValidateOrder(orderItem))
            {
                return false;
            }
            if(orderItem.Id < 1)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateOrderA(OrderItem orderItem)
        {
            if (orderItem.IdBuyer < 1)
            {
                return false;
            }
            if (orderItem.IdProduct < 1)
            {
                return false;
            }
            if (orderItem.ProductAmount < 1)
            {
                return false;
            }
            if (orderItem.TotalPrice < 0)
            {
                return false;
            }
            if (orderItem.InsertDate > DateTime.Now)
            {
                return false;
            }
            if (orderItem.UpdateDate < orderItem.InsertDate)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateInsertedOrderA(OrderItem orderItem)
        {
            if (!ValidateOrderA(orderItem))
            {
                return false;
            }
            if (orderItem.Id < 1)
            {
                return false;
            }
            return true;
        }
    }
}