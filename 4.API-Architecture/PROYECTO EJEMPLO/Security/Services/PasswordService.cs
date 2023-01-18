using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Security.IServices;

namespace Security.Services
{
    public class PasswordService : IPasswordService
    {
        public bool IsValidPassword(string password)
        {
            //not implemented
            return true;
        }
        public string GenerateNewRandomPassword()
        {
            //not implemented
            return "";
        }
        private byte[] EncryptPassword(string password)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(password));

            return hashValue;
        }
        public bool IsCorrectPassword(string encryptedPassword, string password)
        {
            if(encryptedPassword == EncryptPassword(password).ToString())
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
