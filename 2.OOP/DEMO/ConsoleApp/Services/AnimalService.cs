using ConsoleApp.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class AnimalService : IAnimalService
    {
        public void ShowAnimalMenu()
        {
            Console.WriteLine("1. Insertar Gato.");
            Console.WriteLine("2. Insertar Perro.");
            Console.WriteLine("3. Obtener lista de emails de los llamados dueños.");
            Console.WriteLine("4. Calcular total de comida semanal perruna.");
            Console.WriteLine("5. Calcular total de comida semanal gatuna.");
            Console.WriteLine("6. Mostrar productos disponibles para cada animal.");
            Console.WriteLine("0. Salir.");
        }
        public Dog CreateDog()
        {
            Console.WriteLine("Escriba el nombre de su Perro.");
            var newDog = new Dog(Console.ReadLine());
            Console.WriteLine("Escriba cuántos kilos de comida por semana necesita su Perro.");
            newDog.FoodPerDayKG = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Escriba su email.");
            newDog.OwnerEmail = Console.ReadLine();

            return newDog;
        }
        public Cat CreateCat()
        {
            Console.WriteLine("Escriba el nombre de su Gato.");
            var newCat = new Cat(Console.ReadLine());
            Console.WriteLine("Escriba cuántos kilos de comida por semana necesita su Gato.");
            newCat.FoodPerDayKG = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Escriba su email.");
            newCat.OwnerEmail = Console.ReadLine();

            return newCat;
        }
        public List<string> GetOwnersEmails(List<Animal> animalList)
        {
            var emailList = new List<string>();
            foreach (var a in animalList)
            {
                emailList.Add(a.OwnerEmail);
            }

            return emailList;
        }
        public decimal CalculateTotalDogWeekFood(List<Dog> dogList)
        {
            decimal totalAmount = 0;
            foreach (var d in dogList)
            {
                totalAmount += d.FoodPerDayKG;
            }
            return totalAmount;
        }
        public decimal CalculateTotalCatWeekFood(List<Cat> catList)
        {
            decimal totalAmount = 0;
            foreach (var c in catList)
            {
                totalAmount += c.FoodPerDayKG;
            }
            return totalAmount;
        }
    }
}
