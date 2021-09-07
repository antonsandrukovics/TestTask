using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Client
    {
        [Key]
        public int ClientID { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [Display(Name = "Client email")]
        public string Email { get; set; }


        [DataType(DataType.Date)]
        [Required]
        public DateTime Birthdate { get; set; }


        [Required]
        public Gender Gender { get; set; }
        public List<Order> Orders { get; set; }
    }
}
