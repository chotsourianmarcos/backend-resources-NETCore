using APIService.IServices;
using Entities.Entities;
using Entities.RequestModels;
using Logic.ILogic;

namespace APIService.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductLogic _productLogic;
        public ProductService(IProductLogic productLogic) {
            _productLogic = productLogic;
        }
        public int InsertProduct(NewProductRequest newProductRequest)
        {
            var productItem = ToProductItem(newProductRequest);
            _productLogic.InsertProductItem(productItem);
            return productItem.Id;
        }
        public List<OrderItem> GetProductOrders(int id) 
        {
            return _productLogic.GetProductOrders(id);
        }
        public ProductItem ToProductItem(NewProductRequest newProductRequest)
        {
            var productItem = new ProductItem();
            productItem.IdWeb = Guid.NewGuid();
            productItem.Name = newProductRequest.Name;
            productItem.InsertDate = DateTime.Now;
            productItem.UpdateDate = DateTime.Now;
            productItem.IsActive = true;
            productItem.IsPublic = true;
            productItem.RawPrice = newProductRequest.RawPrice;
            return productItem;
        }
    }
}
