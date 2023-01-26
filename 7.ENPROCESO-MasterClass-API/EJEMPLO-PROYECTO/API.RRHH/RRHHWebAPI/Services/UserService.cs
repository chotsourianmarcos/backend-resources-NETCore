using Entities.Entities;
using Resources.FilterModels;
using Resources.RequestModels;
using RRHHWebAPI.IServices;

namespace RRHHWebAPI.Services
{
    public class UserService : IUserService
    {
        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserItem> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public List<UserItem> GetUsersByCriteria(UserFilter userFilter)
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
