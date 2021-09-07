using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask
{
    public class ClientData
    {
        public int ID { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }


        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthdate { get; set; }


        [Required]
        public Gender Gender { get; set; }
        public List<Order> Orders { get; set; }

        [Display(Name = "Average Order Amount")]
        [DataType(DataType.Currency)]
        public decimal AverageOrderAmount { get; set; }

        [Display(Name = "The number of orders")]
        public int TheNumberOfOrder { get; set; }
    }
}
