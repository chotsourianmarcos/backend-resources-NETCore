using Entities.Entities;

namespace APIService.IServices
{
    public interface IProductService
    {
        int InsertProduct(ProductItem productItem);
        public List<OrderItem> GetProductOrders(int id);
    }
}
