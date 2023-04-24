using API.IServices;
using API.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpPost(Name = "InsertProduct")]
        public int Add([FromBody] ProductItem ProductItem)
        {

            return _ProductService.InsertProduct(ProductItem);
        }

        [HttpPatch(Name = "UpdateProduct")]
        public void Update([FromBody] ProductItem ProductItem)
        {

            _ProductService.UpdateProduct(ProductItem);
        }

        [HttpGet(Name = "GetProducts")]
        public List<ProductItem> GetAll()
        {

            return _ProductService.GetProducts();
        }

        [HttpGet(Name = "GetProductById")]
        public ProductItem GetById(int id)
        {

            return _ProductService.GetProductById(id);
        }

        [HttpDelete(Name = "DeactivateProduct")]
        public void Deactivate(int id)
        {

            _ProductService.DeactivateProduct(id);
        }
    }
}
