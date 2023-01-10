using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class User
    {
        public User() { }
        //public User(int id) {
        //    this.Id = id;
        //}

        //public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Origin { get; set; }
    }
}
