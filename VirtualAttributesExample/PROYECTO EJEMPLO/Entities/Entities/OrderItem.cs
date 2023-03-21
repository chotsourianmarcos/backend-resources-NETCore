using System.Text.Json.Serialization;

namespace Entities.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public int IdProduct { get; set; }
        [JsonIgnore]
        public virtual ProductItem Product { get; set;}
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsPayed { get; set; }
    }
}
