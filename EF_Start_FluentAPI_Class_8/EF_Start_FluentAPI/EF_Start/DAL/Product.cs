using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_Start.DAL
{    
    public class Product
    {
        public Product()
        {
            this.Name = "ABC"; //default value
        }
                
        public int ProductId { get; set; }        
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public int CategoryId { get; set; }        
        public virtual Category Category { get; set; } //navigation property : one
    }
}