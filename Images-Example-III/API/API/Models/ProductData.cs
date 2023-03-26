namespace API.Models
{
    public class ProductData
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public ProductItem ToProductItem()
        {
            ProductItem productItem = new ProductItem();
            productItem.Name = Title;
            productItem.Price = Price;
            return productItem;
        }
    }
}
