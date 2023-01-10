using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Dog : Animal
    {
        public Dog(string name)
        {   
            this.Name = name;
            this.InsertDate = DateTime.Now;
        }
        public bool HasAntirabiesVaccine { get; set; }
        public bool IsTrained { get; set; }

        public override string GetAvailableProducts()
        {
            return "Los productos disponibles para este perro son hueso, antipulgas y vacuna antirrábica.";
        }

        public string SignInObstacleRace()
        {
            return "Enhorabuena, la inscripción a la carrera de obstáculos ha sido exitosa.";
        }
    }
}
