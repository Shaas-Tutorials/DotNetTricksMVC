﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_Start.DAL
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } //many
    }
}