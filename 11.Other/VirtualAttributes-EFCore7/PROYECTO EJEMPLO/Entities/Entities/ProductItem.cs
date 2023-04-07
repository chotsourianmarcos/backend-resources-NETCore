using System.Text.Json.Serialization;

namespace Entities.Entities
{
    public class ProductItem
    {
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public string Name { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; set; }
        public decimal RawPrice { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderItem> Orders { get; set; }
    }
}
