using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.IServices
{
    public interface IAnimalShopService
    {
        void ShowAnimalMenu();
        Dog CreateDog();
        Cat CreateCat();
        List<string> GetOwnersEmails(List<Animal> animalList);
        decimal CalculateTotalDogWeekFood(List<Dog> dogList);
        decimal CalculateTotalCatWeekFood(List<Cat> catList);
    }
}
