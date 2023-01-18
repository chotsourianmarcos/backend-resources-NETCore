using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.IServices
{
    public interface IPasswordService
    {
        bool IsValidPassword(string password);
        string GenerateNewRandomPassword();
        bool IsCorrectPassword(string loginName, string password);
    }
}
