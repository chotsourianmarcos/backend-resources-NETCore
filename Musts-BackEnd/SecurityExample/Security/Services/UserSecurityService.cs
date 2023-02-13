using Logic.ILogic;
using Security.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Services
{
    public class UserSecurityService : IUserSecurityService
    {
        private readonly IUserSecurityLogic _userSecurityLogic;
        public UserSecurityService(IUserSecurityLogic userSecurityLogic) 
        {
            _userSecurityLogic = userSecurityLogic;
        }
        private string EncryptPassword(string userPassWord)
        {
            return BCrypt.Net.BCrypt.HashPassword(userPassWord);
        }
        public bool ValidateUserCredentials(string userName, string userPassword)
        {
            var userPasswordEncrypted = this.EncryptPassword(userPassword);
            return _userSecurityLogic.ValidateUserCredentials(userName, userPasswordEncrypted);
        }
        private void RefreshUserToken(string userName)
        {
            _userSecurityLogic.RefreshUserToken(userName);
        }
        public string ReturnUserToken(string userName, string userPassword)
        {
            var userPasswordEncrypted = this.EncryptPassword(userPassword);
            return _userSecurityLogic.ReturnUserToken(userName, userPasswordEncrypted);
        }
        public bool ValidateUserToken(string userName, string token)
        {
            return _userSecurityLogic.ValidateUserToken(userName, token);
        }
    }
}
