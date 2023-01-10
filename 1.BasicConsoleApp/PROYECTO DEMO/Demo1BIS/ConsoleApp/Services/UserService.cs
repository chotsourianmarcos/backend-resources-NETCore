using ConsoleApp.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class UserService : IUserService
    {
        public decimal CalculateUsersAverageAge(List<User> userList)
        {
            var count = 0;
            var sum = 0;

            foreach (var user in userList)
            {
                count++;
                sum += user.Age;
            }

            return sum / count;
        }

        public User CreateUser()
        {
            var newUser = new User();

            Console.WriteLine("Ingrese nombre Usuario");
            newUser.Name = Console.ReadLine();
            Console.WriteLine("Ingrese apellido Usuario");
            newUser.LastName = Console.ReadLine();
            Console.WriteLine("Ingrese edad Usuario");
            newUser.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese origen Usuario");
            newUser.Origin = Console.ReadLine();

            return newUser;
        }

        public void ShowUserMenu()
        {
            Console.WriteLine("1. Ingresar Usuario");
            Console.WriteLine("2. Mostrar Usuarios");
            Console.WriteLine("3. Calcular promedio edades Usuarios");
            Console.WriteLine("0. Salir");
        }

        //public void DeleteUser(User user) { 
        
        //}
    }
}
