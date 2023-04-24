using API.IServices;
using API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderController
    {
        private readonly IOrderService _orderService;
        public readonly IEmailService _emailService;

        public OrderController(IOrderService orderService,
                                IEmailService emailService)
        {
            _orderService = orderService;
            _emailService = emailService;   
        }

        [HttpPost(Name = "InsertOrder")]
        public int Add([FromBody] OrderItem orderItem)
        {

            var orderId = _orderService.InsertOrder(orderItem);
            _emailService.SendNewOrderNotification(orderItem);
            return orderId;
        }

        [HttpPatch(Name = "UpdateOrder")]
        public void Update([FromBody] OrderItem orderItem)
        {

            _orderService.UpdateOrder(orderItem);
        }

        [HttpGet(Name = "GetOrders")]
        public List<OrderItem> GetAll()
        {

            return _orderService.GetOrders();
        }

        [HttpGet(Name = "GetOrderById")]
        public OrderItem GetById(int id)
        {

            return _orderService.GetOrderById(id);

        }

        [HttpDelete(Name = "DeactivateOrder")]
        public void Deactivate(int id)
        {

            _orderService.DeactivateOrder(id);
        }
    }
}
