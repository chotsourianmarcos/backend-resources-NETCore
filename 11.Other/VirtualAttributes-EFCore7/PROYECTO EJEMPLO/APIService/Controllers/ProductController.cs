using APIService.IServices;
using Entities.Entities;
using Entities.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost(Name = "InsertProduct")]
        public int Post([FromBody]NewProductRequest newProductRequest)
        {
            return _productService.InsertProduct(newProductRequest);
        }
        [HttpGet(Name = "GetProductOrders")]
        public List<OrderItem> GetOrders([FromQuery] int idProduct)
        {
            return _productService.GetProductOrders(idProduct);
        }
    }
}
