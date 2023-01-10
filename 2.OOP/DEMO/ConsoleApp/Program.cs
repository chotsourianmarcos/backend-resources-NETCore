using ConsoleApp.IServices;
using ConsoleApp.Services;
using Entities.Entities;

var animalList = new List<Animal>();

IAnimalShopService animalService = new AnimalShopService();

animalService.ShowAnimalMenu();

var option = Convert.ToInt32(Console.ReadLine());

while(option != 0)
{
    if(option == 1){
        animalList.Add(animalService.CreateCat());
        Console.WriteLine("El Gato ha sido ingresado correctamente." + "\n");
    }
    else if(option == 2)
    {
        animalList.Add(animalService.CreateDog());
        Console.WriteLine("El Perro ha sido ingresado correctamente." + "\n");
    }
    else if(option == 3)
    {
        var ownersEmailsList = animalService.GetOwnersEmails(animalList);
        Console.WriteLine("Los Emails de los dueños de animales son:");
        foreach (var e in ownersEmailsList)
        {
            Console.WriteLine(e);
        }
        Console.WriteLine("");
    }
    else if(option == 4)
    {
        decimal totalDogWeekFood = 0;
        foreach(var a in animalList)
        {
            if(a is Dog)
            {
                totalDogWeekFood += a.FoodPerDayKG;
            }
        }
        Console.WriteLine("El total de comida perruna necesario por semana es " + totalDogWeekFood + "\n");
    }
    else if(option == 5)
    {
        decimal totalCatWeekFood = 0;
        foreach (var a in animalList)
        {
            if(a is Cat)
            {
                totalCatWeekFood += a.FoodPerDayKG;
            }
            
        }
        Console.WriteLine("El total de comida gatuna necesario por semana es " + totalCatWeekFood + "\n");
    }else if(option == 6)
    {
        foreach(var a in animalList)
        {
            Console.WriteLine(a.Name + " " + a.GetAvailableProducts());
        }
        Console.WriteLine("");
    }

    animalService.ShowAnimalMenu();
    option = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Adiós, muchas gracias!" + "\n");