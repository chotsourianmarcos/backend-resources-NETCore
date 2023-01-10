using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public abstract class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDay { get; set; }
        public decimal FoodPerDayKG { get; set; }
        public string OwnerEmail { get; set; }
        public byte[] Image { get; set; }
        public DateTime InsertDate { get; set; }

        public abstract string GetAvailableProducts();

        public decimal CalculateWeekFood()
        {
            return FoodPerDayKG * 7;
        }
        public void SendOwnerAnEmail(string emailContent)
        {
            throw new NotImplementedException();
        }
    }
}
