namespace Entities.RequestModels
{
    public class NewOrderRequest
    {
        public int IdProduct { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
