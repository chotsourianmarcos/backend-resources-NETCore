using APIService.IServices;
using Entities.Entities;
using Logic.ILogic;

namespace APIService.Services
{
    public class UserService :IUserService
    {
        private readonly IUserLogic _userLogic;
        public UserService(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public int InsertUser(UserItem userItem)
        {
            _userLogic.InsertUserItem(userItem);
            return userItem.Id;
        }
    }
}
