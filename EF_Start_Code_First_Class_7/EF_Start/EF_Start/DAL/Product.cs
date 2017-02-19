using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EF_Start.DAL
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            this.Name = "ABC"; //default value
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Column(TypeName="varchar")]
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        //[ForeignKey("Category")] //navigation property name
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")] //product class property name
        public virtual Category Category { get; set; } //navigation property : one
    }
}