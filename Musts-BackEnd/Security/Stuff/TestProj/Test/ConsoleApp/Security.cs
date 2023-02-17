using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp
{
    public class Security
    {
        public string HashString(string key)
        {
            return BCrypt.Net.BCrypt.HashPassword(key);
        }
    }
}
