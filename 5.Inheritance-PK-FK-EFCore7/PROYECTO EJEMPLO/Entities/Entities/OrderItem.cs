using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsPayed { get; set; }
    }
}
