using Entities.Entities;
using Entities.RequestModels;

namespace APIService.IServices
{
    public interface IProductService
    {
        int InsertProduct(NewProductRequest newProductRequest);
        public List<OrderItem> GetProductOrders(int id);
    }
}
