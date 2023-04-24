namespace API.Models.Entities
{
    public class ProductItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int IdPhotoFile { get; set; }
        public int IdBrand { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsActive { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
