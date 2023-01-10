using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Cat : Animal
    {
        public Cat(string name)
        {
            this.Name = name;
            this.InsertDate = DateTime.Now;
        }
        public bool HasFVRCPVaccine { get; set; }
        public bool HuntsWildAnimals { get; set; }

        public override string GetAvailableProducts()
        {
            return "Los productos disponibles para este gato son cascabel, ovillo y vacuna FVRCPV.";
        }

        public string ParticipateInBeautyOnlineContest()
        {
            return "Felicitaciones, su gato es muy bello!";
        }
    }
}
