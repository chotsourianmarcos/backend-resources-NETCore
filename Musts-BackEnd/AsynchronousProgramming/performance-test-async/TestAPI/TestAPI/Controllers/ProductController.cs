using Microsoft.AspNetCore.Mvc;
using TestAPI.IServices;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost(Name = "PostAssyynnc")]
        public async Task PostAssyynnc([FromBody] List<ProductItem> productList)
        {
            try
            {
               await _productService.AddProductsAsync(productList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost(Name = "Post")]
        public void Post([FromBody] List<ProductItem> productList)
        {
            try
            {
                _productService.AddProducts(productList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}