using Entities.Entities;
using RRHHWebAPI.Models.Requests;

namespace RRHHWebAPI.IServices
{
    public interface IUserService
    {
        int InsertUser(NewUserRequest newProductRequest);
        void UpdateUser(UserItem userItem);
        void DeleteUser(int id);
        List<UserItem> GetAllUsers();

    }
}
