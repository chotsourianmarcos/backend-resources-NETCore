﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertDate { get; set; }
        public bool Active { get; set; }
    }
}
