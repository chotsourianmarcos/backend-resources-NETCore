using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserItem
    {
        public UserItem() { }
        public int Id { get; set; }
        public int IdRol { get; set; }
        //public virtual UserRol UserRol { get; set; } adicional!
        public string UserName { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }

        //------------------------------------
        //los atributos de seguridad deberían ir en una segunda tabla?
        public string EncryptedPassword { get; set; }


        //una manera mejor sería no guardar el token en DB, trabajando con  JWT y validando en server con API Key
        public string EncryptedToken { get; set; }


        public DateTime TokenExpireDate { get; set; }
        public int FailedConsecutiveLogins { get; set; }
        //bloquear según esto y tal

        //public void RefreshToken()
        //{
        //    SHA256 sha256 = SHA256Managed.Create();
        //    ASCIIEncoding encoding = new ASCIIEncoding();
        //    byte[] stream = null;
        //    StringBuilder sb = new StringBuilder();
        //    stream = sha256.ComputeHash(encoding.GetBytes(this.UserName + this.TokenKey.ToString()));
        //    for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            
        //    this.Token = sb.ToString();
        //    this.TokenExpireDate = DateTime.Now.AddMinutes(5);
        //}
    }
}
