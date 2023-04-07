using APIService.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost(Name = "InsertProduct")]
        public int Post([FromBody]ProductItem productItem)
        {
            //     _userService.ValidateCredentials(userItem);
            return _productService.InsertProduct(productItem);
        }

        [HttpGet(Name = "GetAllProducts")]
        public List<ProductItem> GetAll()
        {
            //     _userService.ValidateCredentials(userItem);
            return _productService.GetAllProducts();
        }

        [HttpGet(Name = "GetProductsByCriteria")]
        public List<ProductItem> GetByCriteria(bool isActive)
        {
            var productFilter = new ProductFilter();
            productFilter.IsActive = isActive;
            return _productService.GetProductsByCriteria(productFilter);
        }
    }
}
