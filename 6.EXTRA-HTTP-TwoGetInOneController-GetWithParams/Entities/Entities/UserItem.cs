using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserItem : PersonItem
    {
        public UserItem()
        {
            IsActive = true;
        }
        public string UserName { get; set; }
        public bool IsActive { get; private set; }
        public int IdRol { get; set; }
        private string EncryptedPassword { get; set; }
    }
}
