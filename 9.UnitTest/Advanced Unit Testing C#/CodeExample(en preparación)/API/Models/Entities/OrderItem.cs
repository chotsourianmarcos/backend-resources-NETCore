namespace API.Models.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int IdBuyer { get; set; }
        public int IdProduct { get; set; }
        public decimal ProductAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPayed { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsActive { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
