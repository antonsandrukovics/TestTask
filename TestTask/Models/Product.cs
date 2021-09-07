using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }


        [RegularExpression("0*[1-9][0-9]*")]
        [Required]
        [Display(Name = "Product code")]
        public int Code { get; set; }


        [Display(Name = "Product Name")]
        [Required]
        [StringLength(50)]
        public string Title { get; set; }


        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        [Display(Name = "Product price")]
        public decimal Price { get; set; }
    }
}
