using Entities.Entities;
using RRHHWebAPI.IServices;
using RRHHWebAPI.Models.Requests;

namespace RRHHWebAPI.Services
{
    public class UserService : IUserService
    {
        private IUserLogic _userLogic;
        public UserService() { }
        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserItem> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public int InsertUser(NewUserRequest newProductRequest)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserItem userItem)
        {
            throw new NotImplementedException();
        }
    }
}
