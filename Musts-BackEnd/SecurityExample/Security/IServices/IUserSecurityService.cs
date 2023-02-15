using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.IServices
{
    public interface IUserSecurityService
    {
        string GenerateAuthorizationToken(string userName, string userPassword);
        //string ReturnUserToken(string userName, string userPasswordEncrypted);
        bool ValidateUserToken(string userName, string token);
    }
}
