using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserItem
    {
        public UserItem() { }
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public int IdRol { get; set; }
        public string UserName { get; set; }
        public string EncryptedPassword { get; set; }
        private Guid TokenKey { get; set; }
        public string Token { get; set; }
        private DateTime TokenExpireDate { get; set; }
        private int FailedConsecutiveLogins { get; set; }

        public void RefreshToken()
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(this.UserName + this.TokenKey.ToString()));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            
            this.Token = sb.ToString();
            this.TokenExpireDate = DateTime.Now.AddMinutes(5);
        }
    }
}
