using APIService.IServices;
using Entities.Entities;
using Entities.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost(Name = "InsertOrder")]
        public int Post([FromBody] NewOrderRequest newOrderRequest)
        {
            return _orderService.InsertOrder(newOrderRequest);
        }

        [HttpGet(Name = "GetProductrawPrice")]
        public decimal GetProductrawPrice([FromQuery] int idOrder)
        {
            return _orderService.GetProductRawPrice(idOrder);
        }
        [HttpGet(Name = "GetProduct")]
        public ProductItem GetProductItem([FromQuery] int idOrder)
        {
            return _orderService.GetProductItem(idOrder);
        }
    }
}
