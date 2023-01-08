using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.IServices
{
    public interface IUserService
    {
        void ShowUserMenu();
        User CreateUser();
        decimal CalculateUsersAverageAge(List<User> userList);
    }
}
