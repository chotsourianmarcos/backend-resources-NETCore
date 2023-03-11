namespace TestAPI.Models
{
    public class ProductItem
    {
        public ProductItem()
        {
            IsActive = true;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
