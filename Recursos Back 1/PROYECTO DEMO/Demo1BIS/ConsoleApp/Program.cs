using ConsoleApp.IServices;
using ConsoleApp.Services;
using Entities.Entities;

List<User> userList = new List<User>();

IUserService userService = new UserService();

//var ejemploDeUsuario = new User();
//var ejemploSegundoUsuario = new User();

//var interfazInstanciada = new IUserService();

userService.ShowUserMenu();

var option = Convert.ToInt32(Console.ReadLine());

while(option != 0)
{
    if(option == 1)
    {
        userList.Add(userService.CreateUser());
    }
    if (option == 2)
    {
        foreach(var u in userList)
        {
            Console.WriteLine(
                u.Name + " " +
                u.LastName + " " +
                u.Age + " " +
                u.Origin + " ");
        }
    }
    if (option == 3)
    {
        Console.WriteLine("El promedio de edades es: " + userService.CalculateUsersAverageAge(userList));
    }

    userService.ShowUserMenu();
    option = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Adiós, muchas gracias!");