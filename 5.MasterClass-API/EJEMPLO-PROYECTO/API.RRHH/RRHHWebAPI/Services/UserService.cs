﻿using Entities.Entities;
using Logic.ILogic;
using Resources.FilterModels;
using Resources.RequestModels;
using RRHHWebAPI.IServices;

namespace RRHHWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserLogic _userLogic;
        public UserService(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public void DeleteUser(int id)
        {
            _userLogic.DeleteUser(id);
        }

        public List<UserItem> GetAllUsers()
        {
            return _userLogic.GetAllUsers();
        }

        public List<UserItem> GetUsersByCriteria(UserFilter userFilter)
        {
            return _userLogic.GetUsersByCriteria(userFilter);
        }

        public int InsertUser(NewUserRequest newUserRequest)
        {
            var newUserItem = newUserRequest.ToUserItem();
            return _userLogic.InsertUser(newUserItem);
        }
        
        public void UpdateUser(UserItem userItem)
        {
            _userLogic.UpdateUser(userItem);
        }
    }
}
