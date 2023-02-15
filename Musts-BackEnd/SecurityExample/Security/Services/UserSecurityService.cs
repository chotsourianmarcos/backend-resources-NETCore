using Logic.ILogic;
using Security.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public string GenerateAuthorizationToken(string userName, string userPassword)
        {
            return _userSecurityLogic.GenerateAuthorizationToken(userName, userPassword);
        }
        //private string RefreshUserToken(string userName)
        //{
        //    string secureRandomString = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        //    string newEncryptedToken = this.EncryptString(secureRandomString);
        //    _userSecurityLogic.RefreshUserToken(userName, newEncryptedToken);
        //    return secureRandomString;
        //}
        public bool ValidateUserToken(string userName, string token)
        {
            return _userSecurityLogic.ValidateUserToken(userName, token);
        }
    }
}
