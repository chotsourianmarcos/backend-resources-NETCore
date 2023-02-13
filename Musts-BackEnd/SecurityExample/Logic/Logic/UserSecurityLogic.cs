using Data;
using Entities.Entities;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class UserSecurityLogic : IUserSecurityLogic
    {
        private readonly ServiceContext _serviceContext;
        public UserSecurityLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public void RefreshUserToken(string userName)
        {
            var user = _serviceContext.Set<UserItem>()
                .Where(u => u.UserName == userName).First();
            user.RefreshToken();
            _serviceContext.Update(user);
            _serviceContext.SaveChanges();
        }

        public string ReturnUserToken(string userName, string userPasswordEncrypted)
        {
            if (this.ValidateUserPassword(userName, userPasswordEncrypted))
            {
                var user = _serviceContext.Set<UserItem>()
                    .Where(u => u.UserName == userName).First();
                return user.Token;
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        public bool ValidateUserPassword(string userName, string userPasswordEncrypted)
        {
            var user = _serviceContext.Set<UserItem>()
                     .Where(u => u.UserName == userName && u.EncryptedPassword == userPasswordEncrypted).FirstOrDefault();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateUserToken(string userName, string token)
        {
            var user = _serviceContext.Set<UserItem>()
                     .Where(u => u.UserName == userName && u.Token == token).FirstOrDefault();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
