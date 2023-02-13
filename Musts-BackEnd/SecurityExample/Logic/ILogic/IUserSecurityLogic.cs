using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IUserSecurityLogic
    {
        bool ValidateUserPassword(string userName, string userPasswordEncrypted);
        void RefreshUserToken(string userName);
        string ReturnUserToken(string userName, string userPasswordEncrypted);
        bool ValidateUserToken(string userName, string token);
    }
}
