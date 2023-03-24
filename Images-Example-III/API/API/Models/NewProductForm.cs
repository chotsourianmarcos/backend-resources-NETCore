namespace API.Models
{
    public class NewProductForm
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductItem ToProductItem()
        {
            ProductItem productItem = new ProductItem();
            productItem.Name = Name;
            productItem.Price = Price;
            return productItem;
        }
    }
}
